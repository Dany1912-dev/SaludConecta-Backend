namespace SaludConecta.Core.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime FechaExpiracion { get; set; }
    public bool Revocado { get; set; }
    public string? DispositivoInfo { get; set; }
    public string? DireccionIP { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public Usuario Usuario { get; set; } = null!;
}