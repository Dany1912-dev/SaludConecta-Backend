namespace SaludConecta.Application.DTOs;

public class AntecedentePersonalResult
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public CondicionMedicaResult CondicionMedica { get; set; } = null!;
    public bool Presente { get; set; }
    public DateTime? FechaDiagnostico { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public string? Notas { get; set; }
    public DateTime FechaCreacion { get; set; }
}
