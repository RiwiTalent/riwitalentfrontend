using System.ComponentModel.DataAnnotations;

namespace riwitalentfrontend.Models.DTOs
{
    public class EmailDto
    {
        public List<string>? Recipients { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
