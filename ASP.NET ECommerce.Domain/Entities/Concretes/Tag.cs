using ASP.NET_ECommerce.Domain.Entities.Abstracts;

namespace ASP.NET_ECommerce.Domain.Entities.Concretes;

public class Tag : Entity {
    public string? Name { get; set; }

    // Navigation Property
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
