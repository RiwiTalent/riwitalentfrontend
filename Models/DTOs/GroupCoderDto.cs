using System.ComponentModel.DataAnnotations;

namespace riwitalentfrontend.Models.DTOs
{
    public class GroupCoderDto
    {

        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime Expiration_At { get; set; }
    }
}