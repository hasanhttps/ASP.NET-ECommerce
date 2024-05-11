using Microsoft.EntityFrameworkCore;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_ECommerce.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p=>p.Tags)
            .WithMany(t => t.Products);
    }
}
