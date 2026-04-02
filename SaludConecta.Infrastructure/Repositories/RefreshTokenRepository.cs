using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Entities;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class RefreshTokenRepository : RepositorioBase<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(SaludConectaDbContext context) : base(context)
    {
    }

    public async Task<RefreshToken?> ObtenerPorTokenAsync(string token)
    {
        return await _dbSet
            .Include(r => r.Usuario)
            .FirstOrDefaultAsync(r => r.Token == token);
    }

    public async Task RevocarTodosDelUsuarioAsync(int usuarioId)
    {
        var tokens = await _dbSet
            .Where(r => r.UsuarioId == usuarioId && !r.Revocado)
            .ToListAsync();

        foreach (var token in tokens)
        {
            token.Revocado = true;
        }

        await GuardarCambiosAsync();
    }
}
