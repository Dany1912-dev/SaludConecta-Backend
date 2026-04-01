using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class ProveedorAutenticacion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public TipoProveedor TipoProveedor { get; set; }
    public string? HashContrasena { get; set; }
    public string? GoogleId { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public Usuario Usuario { get; set; } = null!;
}