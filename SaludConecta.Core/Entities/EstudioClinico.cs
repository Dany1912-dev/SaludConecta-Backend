using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class EstudioClinico
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public int? ConsultaId { get; set; }
    public TipoEstudio TipoEstudio { get; set; }
    public string NombreEstudio { get; set; } = string.Empty;
    public string? Laboratorio { get; set; }
    public string? MedicoSolicitante { get; set; }
    public DateTime FechaRealizacion { get; set; }
    public DateTime? FechaResultados { get; set; }
    public string? Observaciones { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
    public Consulta? Consulta { get; set; }
    public ICollection<ArchivoAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivoAdjunto>();
}