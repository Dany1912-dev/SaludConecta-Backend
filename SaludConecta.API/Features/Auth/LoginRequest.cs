using System.ComponentModel.DataAnnotations;

namespace SaludConecta.API.Features.Auth;

public class LoginRequest
{
    [Required(ErrorMessage = "El correo es requerido")]
    [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es requerida")]
    public string Contrasena { get; set; } = string.Empty;
}
