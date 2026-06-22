using System.ComponentModel.DataAnnotations;
using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.Perfiles;

public class ActualizarPerfilRequest
{
    [MaxLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres")]
    public string? NombreCompleto { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public Genero? Genero { get; set; }
    public TipoSangre? TipoSangre { get; set; }
    public Parentesco? Parentesco { get; set; }
    public string? Ocupacion { get; set; }
    public string? LugarNacimiento { get; set; }
    public string? Telefono { get; set; }
    public string? TelefonoEmergencia { get; set; }
    public string? CorreoContacto { get; set; }
    public string? Direccion { get; set; }
    public string? ColorAvatar { get; set; }
}
