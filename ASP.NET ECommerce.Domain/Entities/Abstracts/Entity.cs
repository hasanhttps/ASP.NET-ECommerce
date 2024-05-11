namespace ASP.NET_ECommerce.Domain.Entities.Abstracts;

public abstract class Entity {

    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
