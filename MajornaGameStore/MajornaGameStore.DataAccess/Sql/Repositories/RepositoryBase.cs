using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public abstract class RepositoryBase<TEntity, TId>(MajornaDbContext context) : IService<TEntity, TId> 
    where TEntity : class
{
    protected readonly MajornaDbContext _context = context;

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }


    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _context.Entry(entity).ReloadAsync();

        return entity;
    }

    //Needs to be implemented in each child class
    public abstract Task UpdateAsync(TEntity entity);

    public async Task DeleteAsync(TId id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity is not null)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }


}