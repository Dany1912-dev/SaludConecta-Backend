using System.ComponentModel.DataAnnotations;

namespace SaludConecta.API.Contracts.Antecedentes;

public class GuardarAntecedentePersonalRequest
{
    [Required]
    public int CondicionMedicaId { get; set; }

    public bool Presente { get; set; } = true;

    public DateTime? FechaDiagnostico { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public string? Notas { get; set; }
}
