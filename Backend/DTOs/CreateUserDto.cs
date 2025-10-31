using System.ComponentModel.DataAnnotations;
using Backend.Enums;

namespace Backend.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string FullName { get; set; } = default!;
        public string? Address { get; set; }
        [Required]
        public Role Role { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public string? ExternalId { get; set; }
    }
}