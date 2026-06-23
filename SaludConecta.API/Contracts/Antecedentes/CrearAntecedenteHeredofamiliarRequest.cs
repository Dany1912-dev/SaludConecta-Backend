using System.ComponentModel.DataAnnotations;
using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.Antecedentes;

public class CrearAntecedenteHeredofamiliarRequest
{
    [Required]
    public int CondicionMedicaId { get; set; }

    [Required]
    public ParentescoFamiliar ParentescoFamiliar { get; set; }

    public bool Presente { get; set; } = true;

    public string? Notas { get; set; }
}
