using Api.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Api.Infraestructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        _dbContext.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync( x => x.Id == id);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public async Task<bool> Exists(int id)
    {
        return await _dbContext.Set<TEntity>().AnyAsync( x => x.Id == id);
    }
}
