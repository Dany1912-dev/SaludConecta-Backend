using SaludConecta.Application.DTOs;

namespace SaludConecta.Application.Interfaces.Services;

public interface IEstiloVidaService
{
    Task<EstiloVidaResult?> ObtenerAsync(int perfilId, int usuarioId);
    Task<EstiloVidaResult> GuardarAsync(int perfilId, int usuarioId, GuardarEstiloVidaDto datos);
}
