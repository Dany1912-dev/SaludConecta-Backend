using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IAntecedenteHeredofamiliarRepository : IRepositorioBase<AntecedenteHeredofamiliar>
{
    Task<IEnumerable<AntecedenteHeredofamiliar>> ObtenerPorPerfilAsync(int perfilId);
    Task<AntecedenteHeredofamiliar?> ObtenerConPerfilAsync(int antecedenteId);
}
