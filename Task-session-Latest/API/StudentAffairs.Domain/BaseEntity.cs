namespace StudentAffairs.Domain;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = default;
    public DateTime UpdatedAt { get; set; } = default;
}
