using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class PerfilPacienteRepository : RepositorioBase<PerfilPaciente>, IPerfilPacienteRepository
{
    public PerfilPacienteRepository(SaludConectaDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PerfilPaciente>> ObtenerPorUsuarioIdAsync(int usuarioId)
    {
        return await _dbSet.Where(p => p.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<bool> ExistePerfilPacienteAsync(int usuarioId, string nombreCompleto)
    {
        return await _dbSet.AnyAsync(p => p.UsuarioId == usuarioId && p.NombreCompleto == nombreCompleto);
    }
}