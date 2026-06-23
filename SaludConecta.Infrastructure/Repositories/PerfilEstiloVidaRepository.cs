using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class PerfilEstiloVidaRepository : RepositorioBase<PerfilEstiloVida>, IPerfilEstiloVidaRepository
{
    public PerfilEstiloVidaRepository(SaludConectaDbContext context) : base(context) { }

    public async Task<PerfilEstiloVida?> ObtenerPorPerfilAsync(int perfilId)
        => await _dbSet.FirstOrDefaultAsync(e => e.PerfilPacienteId == perfilId);
}
