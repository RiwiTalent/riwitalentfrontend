namespace riwi.Models;

public class ExternalKey
{
    public string? url { get; set; }
    public string? key { get; set; }
    public string? status { get; set; }
    public DateTime date_Creation { get; set; }
    public DateTime date_Expiration { get; set; }
}