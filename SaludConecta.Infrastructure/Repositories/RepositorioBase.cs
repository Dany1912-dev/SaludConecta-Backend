using Microsoft.EntityFrameworkCore;
using SaludConecta.Core.Interfaces.Repositories;
using SaludConecta.Infrastructure.Data.Context;

namespace SaludConecta.Infrastructure.Repositories;

public class RepositorioBase<T> : IRepositorioBase<T> where T : class
{
    protected readonly SaludConectaDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositorioBase(SaludConectaDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> ObtenerPorIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> ObtenerTodosAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> CrearAsync(T entidad)
    {
        await _dbSet.AddAsync(entidad);
        await GuardarCambiosAsync();
        return entidad;
    }

    public async Task ActualizarAsync(T entidad)
    {
        _dbSet.Update(entidad);
        await GuardarCambiosAsync();
    }

    public async Task EliminarAsync(T entidad)
    {
        _dbSet.Remove(entidad);
        await GuardarCambiosAsync();
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}
