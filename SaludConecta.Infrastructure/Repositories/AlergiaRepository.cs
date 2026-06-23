using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class AlergiaRepository : RepositorioBase<Alergia>, IAlergiaRepository
{
    public AlergiaRepository(SaludConectaDbContext context) : base(context) { }

    public async Task<IEnumerable<Alergia>> ObtenerPorPerfilAsync(int perfilId)
        => await _dbSet
            .Where(a => a.PerfilPacienteId == perfilId && a.Activa)
            .OrderBy(a => a.TipoAlergia)
            .ThenBy(a => a.Descripcion)
            .ToListAsync();

    public async Task<Alergia?> ObtenerConPerfilAsync(int alergiaId)
        => await _dbSet
            .Include(a => a.PerfilPaciente)
            .FirstOrDefaultAsync(a => a.Id == alergiaId);
}
