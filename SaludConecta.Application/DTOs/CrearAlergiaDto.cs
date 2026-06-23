using SaludConecta.Core.Enums;

namespace SaludConecta.Application.DTOs;

public class CrearAlergiaDto
{
    public TipoAlergia TipoAlergia { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public SeveridadAlergia Severidad { get; set; } = SeveridadAlergia.Moderada;
    public DateTime? FechaDiagnostico { get; set; }
}
