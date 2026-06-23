namespace SaludConecta.Application.DTOs;

public class AlergiaResult
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public string TipoAlergia { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Severidad { get; set; } = string.Empty;
    public bool Activa { get; set; }
    public DateTime? FechaDiagnostico { get; set; }
    public DateTime FechaCreacion { get; set; }
}
