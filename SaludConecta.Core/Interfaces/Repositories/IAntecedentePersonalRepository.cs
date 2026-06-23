using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IAntecedentePersonalRepository : IRepositorioBase<AntecedentePersonal>
{
    Task<IEnumerable<AntecedentePersonal>> ObtenerPorPerfilAsync(int perfilId);
    Task<AntecedentePersonal?> ObtenerConPerfilAsync(int antecedenteId);
    Task<bool> ExisteAsync(int perfilId, int condicionMedicaId);
}
