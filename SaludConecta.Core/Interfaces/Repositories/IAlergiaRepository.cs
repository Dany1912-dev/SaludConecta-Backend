using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IAlergiaRepository : IRepositorioBase<Alergia>
{
    Task<IEnumerable<Alergia>> ObtenerPorPerfilAsync(int perfilId);
    Task<Alergia?> ObtenerConPerfilAsync(int alergiaId);
}
