using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.Perfiles;

public class PerfilPacienteResponse
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Genero { get; set; } = string.Empty;
    public string TipoSangre { get; set; } = string.Empty;
    public string Parentesco { get; set; } = string.Empty;
    public string? Ocupacion { get; set; }
    public string? Telefono { get; set; }
    public string? CorreoContacto { get; set; }
    public string ColorAvatar { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
}
