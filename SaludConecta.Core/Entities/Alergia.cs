using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class Alergia
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public TipoAlergia TipoAlergia { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public SeveridadAlergia Severidad { get; set; } = SeveridadAlergia.Moderada;
    public bool Activa { get; set; } = true;
    public DateTime? FechaDiagnostico { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
}