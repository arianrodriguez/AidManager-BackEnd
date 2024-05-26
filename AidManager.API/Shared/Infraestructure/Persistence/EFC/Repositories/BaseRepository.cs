using AidManager.API.Shared.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;

/*
 * BaseRepository class
 * this class is the base class for all repositories, is the abstract class
 * every repository in any bounded context should inherit from this class
 */

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDBContext Context;

    protected BaseRepository(AppDBContext context)
    {
        this.Context = context;
    }
    
    public async Task AddAsync(TEntity entity)
    {
        Console.WriteLine("adding entity in BaseRepository");
        await Context.Set<TEntity>().AddAsync(entity);
    }
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}   