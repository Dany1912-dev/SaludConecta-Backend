namespace SaludConecta.Core.Interfaces.Repositories;

public interface IRepositorioBase<T> where T : class
{
    Task<T?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<T>> ObtenerTodosAsync();
    Task<T> CrearAsync(T entidad);
    Task ActualizarAsync(T entidad);
    Task EliminarAsync(T entidad);
    Task GuardarCambiosAsync();
}
