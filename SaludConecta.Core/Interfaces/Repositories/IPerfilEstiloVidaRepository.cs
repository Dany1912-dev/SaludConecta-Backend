using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IPerfilEstiloVidaRepository : IRepositorioBase<PerfilEstiloVida>
{
    Task<PerfilEstiloVida?> ObtenerPorPerfilAsync(int perfilId);
}
