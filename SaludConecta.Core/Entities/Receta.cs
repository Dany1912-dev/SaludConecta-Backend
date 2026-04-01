namespace SaludConecta.Core.Entities;

public class Receta
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public int? ConsultaId { get; set; }
    public string? RecetadoPor { get; set; }
    public DateTime FechaReceta { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public bool Activa { get; set; } = true;
    public string? Notas { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
    public Consulta? Consulta { get; set; }
    public ICollection<MedicamentoReceta> Medicamentos { get; set; } = new List<MedicamentoReceta>();
    public ICollection<ArchivoAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivoAdjunto>();
}