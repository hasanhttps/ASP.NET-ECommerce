using ASP.NET_ECommerce.Domain.Entities.Abstracts;

namespace ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

public interface IGenericRepository<T> where T : Entity, new() {
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task Update(T entity);
    Task DeleteAsync(int id);
    Task SaveChanges();
}
