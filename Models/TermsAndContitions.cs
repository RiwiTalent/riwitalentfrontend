    using System;

    namespace riwitalentfrontend.Models
    {
        public class TermAndCondition
        {
            public string? Id { get; set; }
            public string? Content { get; set; }
            public DateTime Clicked_Date { get; set; } 
            public bool IsActive { get; set; }
            public bool Accepted { get; set; }
            public int Version { get; set; }
            public string? GroupId { get; set; }
            public string? AcceptedEmail { get; set; }
            public string? CreatorEmail { get; set; }
        }
    }
