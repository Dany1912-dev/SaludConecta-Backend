using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IRefreshTokenRepository : IRepositorioBase<RefreshToken>
{
    Task<RefreshToken?> ObtenerPorTokenAsync(string token);
    Task RevocarTodosDelUsuarioAsync(int usuarioId);
}
