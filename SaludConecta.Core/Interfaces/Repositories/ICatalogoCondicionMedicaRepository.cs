using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface ICatalogoCondicionMedicaRepository : IRepositorioBase<CatalogoCondicionMedica>
{
    Task<IEnumerable<CatalogoCondicionMedica>> ObtenerPorCategoriaAsync(CategoriaCondicionMedica categoria);
    Task<IEnumerable<CatalogoCondicionMedica>> ObtenerTodosOrdenadosAsync();
}
