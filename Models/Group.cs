namespace riwi.Models;

public class Group
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ExternalKey>? ExternalKeys { get; set; }
    public List<Coder>? Coders { get; set; }
}
