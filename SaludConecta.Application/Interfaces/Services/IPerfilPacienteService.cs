using SaludConecta.Application.DTOs;

namespace SaludConecta.Application.Interfaces.Services;

public interface IPerfilPacienteService
{
    Task<IEnumerable<PerfilPacienteResult>> ObtenerPerfilesAsync(int usuarioId);
    Task<PerfilPacienteResult> ObtenerPerfilAsync(int perfilId, int usuarioId);
    Task<PerfilPacienteResult> CrearPerfilAsync(int usuarioId, CrearPerfilPacienteDto datos);
    Task<PerfilPacienteResult> ActualizarPerfilAsync(int perfilId, int usuarioId, ActualizarPerfilPacienteDto datos);
    Task DesactivarPerfilAsync(int perfilId, int usuarioId);
}
