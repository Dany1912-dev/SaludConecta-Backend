using SaludConecta.Core.Enums;

namespace SaludConecta.Application.DTOs;

public class CrearPerfilPacienteDto
{
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public Genero Genero { get; set; }
    public TipoSangre TipoSangre { get; set; } = TipoSangre.Desconocido;
    public Parentesco Parentesco { get; set; } = Parentesco.Yo;
    public string? Ocupacion { get; set; }
    public string? LugarNacimiento { get; set; }
    public string? Telefono { get; set; }
    public string? TelefonoEmergencia { get; set; }
    public string? CorreoContacto { get; set; }
    public string? Direccion { get; set; }
    public string ColorAvatar { get; set; } = "#6366F1";
}
