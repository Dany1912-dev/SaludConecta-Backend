namespace SaludConecta.Application.DTOs;

public class AntecedentePsicologicoResult
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public string NombreCondicion { get; set; } = string.Empty;
    public DateTime? FechaDiagnostico { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public bool Activo { get; set; }
    public string? NotasTratamiento { get; set; }
    public DateTime FechaCreacion { get; set; }
}
