namespace SaludConecta.Core.Entities;

public class RegistroBiometrico
{
    public int Id { get; set; }
    public int PerfilPacienteId { get; set; }
    public decimal? PesoKg { get; set; }
    public decimal? EstaturaCm { get; set; }
    public string? Notas { get; set; }
    public DateTime FechaRegistro { get; set; }

    // Navegación
    public PerfilPaciente PerfilPaciente { get; set; } = null!;
}