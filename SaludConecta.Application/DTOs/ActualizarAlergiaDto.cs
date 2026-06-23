using SaludConecta.Core.Enums;

namespace SaludConecta.Application.DTOs;

public class ActualizarAlergiaDto
{
    public TipoAlergia? TipoAlergia { get; set; }
    public string? Descripcion { get; set; }
    public SeveridadAlergia? Severidad { get; set; }
    public DateTime? FechaDiagnostico { get; set; }
}
