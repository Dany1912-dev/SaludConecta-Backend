using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.Alergias;

public class ActualizarAlergiaRequest
{
    public TipoAlergia? TipoAlergia { get; set; }
    public string? Descripcion { get; set; }
    public SeveridadAlergia? Severidad { get; set; }
    public DateTime? FechaDiagnostico { get; set; }
}
