namespace StudentAffairs.Domain;
public class Student : BaseEntity
{
    public string? Name { get; set; } = string.Empty;
    public string? Mobile { get; set; } = string.Empty;
    public string? Telephone { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public string? Message { get; set; } = string.Empty;
    public byte[]? RowVersion { get; set; } = Array.Empty<byte>();
}
