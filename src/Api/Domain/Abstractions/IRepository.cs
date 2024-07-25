namespace Api.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(int id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> Exists(int id);
}
