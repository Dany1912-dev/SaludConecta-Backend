namespace SaludConecta.API.Features.Auth;

public class AuthResponse
{
    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Modo { get; set; } = string.Empty;
}