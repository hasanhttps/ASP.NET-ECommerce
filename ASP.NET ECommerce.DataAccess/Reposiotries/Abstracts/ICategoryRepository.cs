using ASP.NET_ECommerce.Domain.Entities.Concretes;

namespace ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

public interface ICategoryRepository : IGenericRepository<Category> {
    Task<Category> GetByidWithTags(long id);
}
