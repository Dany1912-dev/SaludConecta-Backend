using SaludConecta.Core.Entities;

namespace SaludConecta.Core.Interfaces.Repositories;

public interface IPerfilPacienteRepository : IRepositorioBase<PerfilPaciente>
{
    Task<IEnumerable<PerfilPaciente>> ObtenerPorUsuarioIdAsync(int usuarioId);
    Task<bool> ExistePerfilPacienteAsync(int usuarioId, string nombreCompleto);
}