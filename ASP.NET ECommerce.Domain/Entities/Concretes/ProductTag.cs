using ASP.NET_ECommerce.Domain.Entities.Abstracts;

namespace ASP.NET_ECommerce.Domain.Entities.Concretes;

public class ProductTag : Entity {
    public int CategoryId { get; set; }
    public int TagId { get; set; }

    // Navigation Property
    public virtual Product Product { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
}
