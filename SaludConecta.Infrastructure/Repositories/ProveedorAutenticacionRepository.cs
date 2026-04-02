using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class ProveedorAutenticacionRepository : RepositorioBase<ProveedorAutenticacion>, IProveedorAutenticacionRepository
{
    public ProveedorAutenticacionRepository(SaludConectaDbContext context) : base(context)
    {
    }

    public async Task<ProveedorAutenticacion?> ObtenerPorUsuarioYTipoAsync(int usuarioId, TipoProveedor tipo)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.TipoProveedor == tipo);
    }

    public async Task<ProveedorAutenticacion?> ObtenerPorGoogleIdAsync(string googleId)
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .FirstOrDefaultAsync(p => p.GoogleId == googleId);
    }
}
