namespace SaludConecta.Core.Entities;

public class AntecedentePersonal
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public int CondicionMedicaId { get; set; }
    public bool Presente { get; set; }
    public DateTime? FechaDiagnostico { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public string? Notas { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
    public CatalogoCondicionMedica CondicionMedica { get; set; } = null!;
}