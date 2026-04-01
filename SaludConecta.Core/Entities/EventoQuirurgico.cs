using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class EventoQuirurgico
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public TipoEventoQuirurgico TipoEvento { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime? FechaEvento { get; set; }
    public string? Hospital { get; set; }
    public string? Medico { get; set; }
    public string? Notas { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
}