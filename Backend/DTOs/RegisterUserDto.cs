using System.ComponentModel.DataAnnotations;
using Backend.Enums;

namespace Backend.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string FullName { get; set; } = default!;
        [Phone]
        public string? Phone { get; set; }
        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}