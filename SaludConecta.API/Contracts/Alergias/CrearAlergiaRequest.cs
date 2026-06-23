using System.ComponentModel.DataAnnotations;
using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.Alergias;

public class CrearAlergiaRequest
{
    [Required]
    public TipoAlergia TipoAlergia { get; set; }

    [Required, MaxLength(300)]
    public string Descripcion { get; set; } = string.Empty;

    public SeveridadAlergia Severidad { get; set; } = SeveridadAlergia.Moderada;

    public DateTime? FechaDiagnostico { get; set; }
}
