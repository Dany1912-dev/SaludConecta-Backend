using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class AntecedentePsicologicoRepository : RepositorioBase<AntecedentePsicologico>, IAntecedentePsicologicoRepository
{
    public AntecedentePsicologicoRepository(SaludConectaDbContext context) : base(context) { }

    public async Task<IEnumerable<AntecedentePsicologico>> ObtenerPorPerfilAsync(int perfilId)
        => await _dbSet
            .Where(a => a.PerfilPacienteId == perfilId && a.Activo)
            .OrderByDescending(a => a.FechaCreacion)
            .ToListAsync();

    public async Task<AntecedentePsicologico?> ObtenerConPerfilAsync(int antecedenteId)
        => await _dbSet
            .Include(a => a.PerfilPaciente)
            .FirstOrDefaultAsync(a => a.Id == antecedenteId);
}
