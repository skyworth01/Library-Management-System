using Backend.Enums;

namespace Backend.DTOs
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public required string FullName { get; set; }
        public string? Address { get; set; }
        public Role Role { get; set; }
        public string? Phone { get; set; }
        public string? ExternalId { get; set; }
    }
}