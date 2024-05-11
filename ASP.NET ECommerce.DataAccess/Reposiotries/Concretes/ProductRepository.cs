using Microsoft.EntityFrameworkCore;
using ASP.NET_ECommerce.DataAccess.Contexts;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace ASP.NET_ECommerce.DataAccess.Reposiotries.Concretes;

public class ProductRepository : GenericRepository<Product>, IProductRepository {
    public ProductRepository(AppDbContext context) : base(context) {

    }

    public async Task<Product> GetByidWithTags(int id) {
        return await _context.Products.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
    }
}
