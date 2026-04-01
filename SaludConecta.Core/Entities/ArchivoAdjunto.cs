using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class ArchivoAdjunto
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public int? RecetaId { get; set; }
    public int? ConsultaId { get; set; }
    public int? EstudioClinicoId { get; set; }
    public TipoArchivo TipoArchivo { get; set; }
    public string NombreOriginal { get; set; } = string.Empty;
    public string RutaArchivo { get; set; } = string.Empty;
    public string ExtensionArchivo { get; set; } = string.Empty;
    public long TamanoBytes { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
    public Receta? Receta { get; set; }
    public Consulta? Consulta { get; set; }
    public EstudioClinico? EstudioClinico { get; set; }
}