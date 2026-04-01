using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public bool TelefonoVerificado { get; set; }
    public ModoUsuario Modo { get; set; } = ModoUsuario.Personal;
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }

    // Navegación
    public ICollection<ProveedorAutenticacion> ProveedoresAutenticacion { get; set; } = new List<ProveedorAutenticacion>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<CodigoVerificacion> CodigosVerificacion { get; set; } = new List<CodigoVerificacion>();
    public ICollection<PerfilPaciente> PerfilesPaciente { get; set; } = new List<PerfilPaciente>();
}