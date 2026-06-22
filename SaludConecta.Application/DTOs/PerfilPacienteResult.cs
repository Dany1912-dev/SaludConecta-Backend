using SaludConecta.Core.Enums;

namespace SaludConecta.Application.DTOs;

public class PerfilPacienteResult
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public Genero Genero { get; set; }
    public TipoSangre TipoSangre { get; set; }
    public Parentesco Parentesco { get; set; }
    public string? Ocupacion { get; set; }
    public string? Telefono { get; set; }
    public string? CorreoContacto { get; set; }
    public string ColorAvatar { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
}
