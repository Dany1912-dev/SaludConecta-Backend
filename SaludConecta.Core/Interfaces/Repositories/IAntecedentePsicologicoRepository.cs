using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IAntecedentePsicologicoRepository : IRepositorioBase<AntecedentePsicologico>
{
    Task<IEnumerable<AntecedentePsicologico>> ObtenerPorPerfilAsync(int perfilId);
    Task<AntecedentePsicologico?> ObtenerConPerfilAsync(int antecedenteId);
}
