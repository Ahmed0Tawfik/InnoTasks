namespace StudentAffairs.Application;
public record StudentDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Mobile { get; set; }
    public string? Telephone { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
    public string? Message { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
