namespace SaludConecta.Core.Entities;

public class Consulta
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public DateTime FechaConsulta { get; set; }
    public string? NombreEspecialista { get; set; }
    public string? Especialidad { get; set; }
    public string MotivoConsulta { get; set; } = string.Empty;
    public string? Diagnostico { get; set; }
    public string? Notas { get; set; }
    public DateTime? FechaSeguimiento { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
    public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    public ICollection<EstudioClinico> EstudiosClinicos { get; set; } = new List<EstudioClinico>();
    public ICollection<ArchivoAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivoAdjunto>();
}