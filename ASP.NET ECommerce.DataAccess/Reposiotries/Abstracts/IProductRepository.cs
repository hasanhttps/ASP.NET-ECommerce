using ASP.NET_ECommerce.Domain.Entities.Concretes;

namespace ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

public interface IProductRepository:IGenericRepository<Product> {
    Task<Product> GetByidWithTags(int id);
}
