using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SaludConecta.API.Configurations;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;
using SaludConecta.Core.Exceptions;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Core.Interfaces.Services;

namespace SaludConecta.API.Features.Auth;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IProveedorAutenticacionRepository _proveedorRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        IUsuarioRepository usuarioRepository,
        IProveedorAutenticacionRepository proveedorRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IOptions<JwtSettings> jwtSettings)
    {
        _usuarioRepository = usuarioRepository;
        _proveedorRepository = proveedorRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResult> RegistrarAsync(string nombre, string correo, string contrasena, string? telefono)
    {
        // Verificar si el correo ya existe
        if (await _usuarioRepository.ExisteCorreoAsync(correo))
            throw new ConflictException("Ya existe una cuenta registrada con ese correo");

        // Crear el usuario
        var usuario = new Usuario
        {
            Nombre = nombre,
            Correo = correo.ToLower().Trim(),
            Telefono = telefono,
            TelefonoVerificado = false,
            Modo = ModoUsuario.Personal,
            FechaCreacion = DateTime.UtcNow,
            FechaActualizacion = DateTime.UtcNow
        };

        await _usuarioRepository.CrearAsync(usuario);

        // Crear el proveedor de autenticación local
        var proveedor = new ProveedorAutenticacion
        {
            UsuarioId = usuario.Id,
            TipoProveedor = TipoProveedor.Local,
            HashContrasena = BCrypt.Net.BCrypt.HashPassword(contrasena),
            FechaCreacion = DateTime.UtcNow
        };

        await _proveedorRepository.CrearAsync(proveedor);

        // Generar tokens
        return await GenerarAuthResultAsync(usuario);
    }

    public async Task<AuthResult> LoginAsync(string correo, string contrasena)
    {
        // Buscar usuario por correo
        var usuario = await _usuarioRepository.ObtenerPorCorreoAsync(correo.ToLower().Trim());
        if (usuario == null)
            throw new UnauthorizedException("Correo o contraseña incorrectos");

        // Buscar proveedor local
        var proveedor = usuario.ProveedoresAutenticacion
            .FirstOrDefault(p => p.TipoProveedor == TipoProveedor.Local);

        if (proveedor == null || string.IsNullOrEmpty(proveedor.HashContrasena))
            throw new UnauthorizedException("Esta cuenta no tiene contraseña. Intenta iniciar sesión con Google");

        // Verificar contraseña
        if (!BCrypt.Net.BCrypt.Verify(contrasena, proveedor.HashContrasena))
            throw new UnauthorizedException("Correo o contraseña incorrectos");

        // Generar tokens
        return await GenerarAuthResultAsync(usuario);
    }

    public async Task<AuthResult> RefrescarTokenAsync(string refreshToken)
    {
        var token = await _refreshTokenRepository.ObtenerPorTokenAsync(refreshToken);

        if (token == null)
            throw new UnauthorizedException("Refresh token inválido");

        if (token.Revocado)
            throw new UnauthorizedException("Refresh token revocado");

        if (token.FechaExpiracion < DateTime.UtcNow)
            throw new UnauthorizedException("Refresh token expirado");

        // Revocar el token actual (rotación)
        token.Revocado = true;
        await _refreshTokenRepository.ActualizarAsync(token);

        // Generar nuevos tokens
        return await GenerarAuthResultAsync(token.Usuario);
    }

    public async Task RevocarRefreshTokenAsync(string refreshToken)
    {
        var token = await _refreshTokenRepository.ObtenerPorTokenAsync(refreshToken);

        if (token == null)
            throw new UnauthorizedException("Refresh token inválido");

        token.Revocado = true;
        await _refreshTokenRepository.ActualizarAsync(token);
    }

    private async Task<AuthResult> GenerarAuthResultAsync(Usuario usuario)
    {
        var accessToken = GenerarAccessToken(usuario);
        var refreshToken = await GenerarRefreshTokenAsync(usuario.Id);
        var expiracion = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes);

        return new AuthResult
        {
            UsuarioId = usuario.Id,
            Nombre = usuario.Nombre,
            Correo = usuario.Correo,
            Modo = usuario.Modo.ToString(),
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            AccessTokenExpira = expiracion
        };
    }

    private string GenerarAccessToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Name, usuario.Nombre),
            new(ClaimTypes.Email, usuario.Correo),
            new("modo", usuario.Modo.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<string> GenerarRefreshTokenAsync(int usuarioId)
    {
        var tokenBytes = RandomNumberGenerator.GetBytes(64);
        var tokenString = Convert.ToBase64String(tokenBytes);

        var refreshToken = new RefreshToken
        {
            UsuarioId = usuarioId,
            Token = tokenString,
            FechaExpiracion = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays),
            Revocado = false,
            FechaCreacion = DateTime.UtcNow
        };

        await _refreshTokenRepository.CrearAsync(refreshToken);

        return tokenString;
    }
}
