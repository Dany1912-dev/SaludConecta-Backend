using System.ComponentModel.DataAnnotations;

namespace SaludConecta.API.Contracts.Antecedentes;

public class CrearAntecedentePsicologicoRequest
{
    [Required, MaxLength(200)]
    public string NombreCondicion { get; set; } = string.Empty;

    public DateTime? FechaDiagnostico { get; set; }

    public string? NotasTratamiento { get; set; }
}
