using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IUsuarioRepository : IRepositorioBase<Usuario>
{
    Task<Usuario?> ObtenerPorCorreoAsync(string correo);
    Task<bool> ExisteCorreoAsync(string correo);
}
