using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SaludConecta.API.Configurations;
using SaludConecta.Core.Interfaces.Services;

namespace SaludConecta.API.Features.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly JwtSettings _jwtSettings;

    public AuthController(IAuthService authService, IOptions<JwtSettings> jwtSettings)
    {
        _authService = authService;
        _jwtSettings = jwtSettings.Value;
    }

    [HttpPost("registro")]
    public async Task<ActionResult<AuthResponse>> Registro([FromBody] RegistroRequest request)
    {
        var result = await _authService.RegistrarAsync(
            request.Nombre,
            request.Correo,
            request.Contrasena,
            request.Telefono
        );

        SetearCookiesDeTokens(result.AccessToken, result.RefreshToken);

        return Created("", new AuthResponse
        {
            UsuarioId = result.UsuarioId,
            Nombre = result.Nombre,
            Correo = result.Correo,
            Modo = result.Modo
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(
            request.Correo,
            request.Contrasena
        );

        SetearCookiesDeTokens(result.AccessToken, result.RefreshToken);

        return Ok(new AuthResponse
        {
            UsuarioId = result.UsuarioId,
            Nombre = result.Nombre,
            Correo = result.Correo,
            Modo = result.Modo
        });
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<AuthResponse>> Refresh()
    {
        var refreshToken = Request.Cookies["refresh_token"];

        if (string.IsNullOrEmpty(refreshToken))
            return Unauthorized(new { error = "No se encontró el refresh token" });

        var result = await _authService.RefrescarTokenAsync(refreshToken);

        SetearCookiesDeTokens(result.AccessToken, result.RefreshToken);

        return Ok(new AuthResponse
        {
            UsuarioId = result.UsuarioId,
            Nombre = result.Nombre,
            Correo = result.Correo,
            Modo = result.Modo
        });
    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        var refreshToken = Request.Cookies["refresh_token"];

        if (!string.IsNullOrEmpty(refreshToken))
            await _authService.RevocarRefreshTokenAsync(refreshToken);

        EliminarCookiesDeTokens();

        return NoContent();
    }

    private void SetearCookiesDeTokens(string accessToken, string refreshToken)
    {
        var accessCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes)
        };

        var refreshCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Path = "/api/auth",
            Expires = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays)
        };

        Response.Cookies.Append("access_token", accessToken, accessCookieOptions);
        Response.Cookies.Append("refresh_token", refreshToken, refreshCookieOptions);
    }

    private void EliminarCookiesDeTokens()
    {
        Response.Cookies.Delete("access_token");
        Response.Cookies.Delete("refresh_token", new CookieOptions { Path = "/api/auth" });
    }
}