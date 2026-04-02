namespace SaludConecta.Core.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResult> RegistrarAsync(string nombre, string correo, string contrasena, string? telefono);
    Task<AuthResult> LoginAsync(string correo, string contrasena);
    Task<AuthResult> RefrescarTokenAsync(string refreshToken);
    Task RevocarRefreshTokenAsync(string refreshToken);
}

public class AuthResult
{
    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Modo { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpira { get; set; }
}
