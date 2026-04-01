using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class CodigoVerificacion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public TipoCodigoVerificacion Tipo { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public bool Usado { get; set; }
    public int IntentosFallidos { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public Usuario Usuario { get; set; } = null!;
}