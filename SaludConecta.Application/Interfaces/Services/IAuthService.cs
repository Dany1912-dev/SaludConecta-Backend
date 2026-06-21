using SaludConecta.Application.DTOs;

namespace SaludConecta.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResult> RegistrarAsync(string nombre, string correo, string contrasena, string? telefono);
    Task<AuthResult> LoginAsync(string correo, string contrasena);
    Task<AuthResult> RefrescarTokenAsync(string refreshToken);
    Task RevocarRefreshTokenAsync(string refreshToken);
}
