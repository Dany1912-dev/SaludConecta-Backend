using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class AntecedenteHeredofamiliar
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public ParentescoFamiliar ParentescoFamiliar { get; set; }
    public int CondicionMedicaId { get; set; }
    public bool Presente { get; set; }
    public string? Notas { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
    public CatalogoCondicionMedica CondicionMedica { get; set; } = null!;
}