using ASP.NET_ECommerce.Domain.Entities.Abstracts;

namespace ASP.NET_ECommerce.Domain.Entities.Concretes;

public class CategoryTag : Entity {
    public int CategoryId { get; set; }
    public int TagId { get; set; }

    // Navigation Property
    public virtual Category Category { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
}
