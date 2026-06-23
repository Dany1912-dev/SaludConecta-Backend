using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class AntecedentePersonalRepository : RepositorioBase<AntecedentePersonal>, IAntecedentePersonalRepository
{
    public AntecedentePersonalRepository(SaludConectaDbContext context) : base(context) { }

    public async Task<IEnumerable<AntecedentePersonal>> ObtenerPorPerfilAsync(int perfilId)
        => await _dbSet
            .Include(a => a.CondicionMedica)
            .Where(a => a.PerfilPacienteId == perfilId)
            .OrderBy(a => a.CondicionMedica.Categoria)
            .ThenBy(a => a.CondicionMedica.Orden)
            .ToListAsync();

    public async Task<AntecedentePersonal?> ObtenerConPerfilAsync(int antecedenteId)
        => await _dbSet
            .Include(a => a.PerfilPaciente)
            .Include(a => a.CondicionMedica)
            .FirstOrDefaultAsync(a => a.Id == antecedenteId);

    public async Task<bool> ExisteAsync(int perfilId, int condicionMedicaId)
        => await _dbSet.AnyAsync(a => a.PerfilPacienteId == perfilId && a.CondicionMedicaId == condicionMedicaId);
}
