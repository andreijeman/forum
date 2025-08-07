namespace Forum.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}