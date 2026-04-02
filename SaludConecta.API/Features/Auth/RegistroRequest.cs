using System.ComponentModel.DataAnnotations;

namespace SaludConecta.API.Features.Auth;

public class RegistroRequest
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(150, ErrorMessage = "El nombre no puede exceder 150 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es requerido")]
    [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
    [MaxLength(255, ErrorMessage = "El correo no puede exceder 255 caracteres")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es requerida")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
    public string Contrasena { get; set; } = string.Empty;

    [MaxLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
    public string? Telefono { get; set; }
}
