using System.ComponentModel.DataAnnotations;

namespace SaludConecta.API.Features.Auth;

public class RefreshTokenRequest
{
    [Required(ErrorMessage = "El refresh token es requerido")]
    public string RefreshToken { get; set; } = string.Empty;
}
