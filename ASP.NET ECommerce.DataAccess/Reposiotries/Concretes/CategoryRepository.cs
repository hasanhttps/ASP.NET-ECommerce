using Microsoft.EntityFrameworkCore;
using ASP.NET_ECommerce.DataAccess.Contexts;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace ASP.NET_ECommerce.DataAccess.Reposiotries.Concretes;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository {
    public CategoryRepository(AppDbContext context) : base(context) {
        
    }

    public async Task<Category> GetByidWithTags(long id) {
        return await _context.Categories.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
    }
}   

