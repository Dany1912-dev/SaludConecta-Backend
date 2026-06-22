using System.ComponentModel.DataAnnotations;
using SaludConecta.Core.Enums;

namespace SaludConecta.API.Contracts.Perfiles;

public class CrearPerfilRequest
{
    [Required(ErrorMessage = "El nombre completo es requerido")]
    [MaxLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El género es requerido")]
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
