using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class AntecedenteHeredofamiliarRepository : RepositorioBase<AntecedenteHeredofamiliar>, IAntecedenteHeredofamiliarRepository
{
    public AntecedenteHeredofamiliarRepository(SaludConectaDbContext context) : base(context) { }

    public async Task<IEnumerable<AntecedenteHeredofamiliar>> ObtenerPorPerfilAsync(int perfilId)
        => await _dbSet
            .Include(a => a.CondicionMedica)
            .Where(a => a.PerfilPacienteId == perfilId)
            .OrderBy(a => a.ParentescoFamiliar)
            .ThenBy(a => a.CondicionMedica.Categoria)
            .ToListAsync();

    public async Task<AntecedenteHeredofamiliar?> ObtenerConPerfilAsync(int antecedenteId)
        => await _dbSet
            .Include(a => a.PerfilPaciente)
            .Include(a => a.CondicionMedica)
            .FirstOrDefaultAsync(a => a.Id == antecedenteId);
}
