using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class UsuarioRepository : RepositorioBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(SaludConectaDbContext context) : base(context)
    {
    }

    public async Task<Usuario?> ObtenerPorCorreoAsync(string correo)
    {
        return await _dbSet
            .Include(u => u.ProveedoresAutenticacion)
            .FirstOrDefaultAsync(u => u.Correo == correo);
    }

    public async Task<bool> ExisteCorreoAsync(string correo)
    {
        return await _dbSet.AnyAsync(u => u.Correo == correo);
    }
}
