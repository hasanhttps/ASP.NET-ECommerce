using Microsoft.EntityFrameworkCore;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_ECommerce.DataAccess.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();  
    }
}
