using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class CatalogoCondicionMedicaRepository : RepositorioBase<CatalogoCondicionMedica>, ICatalogoCondicionMedicaRepository
{
    public CatalogoCondicionMedicaRepository(SaludConectaDbContext context) : base(context) { }

    public async Task<IEnumerable<CatalogoCondicionMedica>> ObtenerPorCategoriaAsync(CategoriaCondicionMedica categoria)
        => await _dbSet
            .Where(c => c.Categoria == categoria)
            .OrderBy(c => c.Orden)
            .ThenBy(c => c.NombreCondicion)
            .ToListAsync();

    public async Task<IEnumerable<CatalogoCondicionMedica>> ObtenerTodosOrdenadosAsync()
        => await _dbSet
            .OrderBy(c => c.Categoria)
            .ThenBy(c => c.Orden)
            .ThenBy(c => c.NombreCondicion)
            .ToListAsync();
}
