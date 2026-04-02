using SaludConecta.Core.Entities;
using SaludConecta.Core.Enums;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IProveedorAutenticacionRepository : IRepositorioBase<ProveedorAutenticacion>
{
    Task<ProveedorAutenticacion?> ObtenerPorUsuarioYTipoAsync(int usuarioId, TipoProveedor tipo);
    Task<ProveedorAutenticacion?> ObtenerPorGoogleIdAsync(string googleId);
}
