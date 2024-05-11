using Microsoft.EntityFrameworkCore;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_ECommerce.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
    public void Configure(EntityTypeBuilder<Category> builder) {
        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);


        builder.HasMany(c => c.Tags)
            .WithMany(t => t.Categories);
    }
}
