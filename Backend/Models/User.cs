using Backend.Enums;

namespace Backend.Models
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public required string FullName { get; set; }
        public string? Address { get; set; }
        public Role Role { get; set; } = Role.Member; 
        public string? Phone { get; set; }
        public string? ExternalId { get; set; }
    }
}