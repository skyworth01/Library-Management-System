using Backend.Enums;

namespace Backend.Models
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string EmailId { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public required string FullName { get; set; }
        public string? Address { get; set; }
        public Role Role { get; set; } = Role.User;
        public string? Phone { get; set; }
    }
}