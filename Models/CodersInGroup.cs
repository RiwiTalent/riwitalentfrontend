namespace riwi.Models;

public class CodersInGroup
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string description { get; set; }
    public List<Coder>? coders { get; set; }
}