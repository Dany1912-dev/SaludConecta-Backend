using SaludConecta.Application.DTOs;

namespace SaludConecta.Application.Interfaces.Services;

public interface IAlergiaService
{
    Task<IEnumerable<AlergiaResult>> ObtenerAlergiasAsync(int perfilId, int usuarioId);
    Task<AlergiaResult> CrearAlergiaAsync(int perfilId, int usuarioId, CrearAlergiaDto datos);
    Task<AlergiaResult> ActualizarAlergiaAsync(int alergiaId, int usuarioId, ActualizarAlergiaDto datos);
    Task DesactivarAlergiaAsync(int alergiaId, int usuarioId);
}
