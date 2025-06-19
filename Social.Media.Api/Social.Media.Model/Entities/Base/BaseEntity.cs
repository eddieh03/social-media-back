namespace Social.Media.Model.Entities.Base;

public class BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool SoftDeleted { get; set; } = false;
}
