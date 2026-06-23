namespace SaludConecta.Application.DTOs;

public class AntecedenteHeredofamiliarResult
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public string ParentescoFamiliar { get; set; } = string.Empty;
    public CondicionMedicaResult CondicionMedica { get; set; } = null!;
    public bool Presente { get; set; }
    public string? Notas { get; set; }
    public DateTime FechaCreacion { get; set; }
}
