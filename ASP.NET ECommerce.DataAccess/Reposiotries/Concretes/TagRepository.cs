using ASP.NET_ECommerce.DataAccess.Contexts;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace ASP.NET_ECommerce.DataAccess.Reposiotries.Concretes;

public class TagRepository : GenericRepository<Tag>, ITagRepository {
    public TagRepository(AppDbContext context) : base(context)  {
    }
}
