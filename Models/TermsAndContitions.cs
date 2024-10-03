using System;

namespace riwi.Models
{
    public class TermAndCondition
    {
        public string? Id { get; set; }
        public string? Content { get; set; }
        public DateTime Clicked_Date { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool Accepted { get; set; } = false;
        public int Version { get; set; }
        public string? GroupId { get; set; }
        public string? AcceptedEmail { get; set; }
        public string? CreatorEmail { get; set; }
    }
}
