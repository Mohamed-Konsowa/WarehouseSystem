
namespace WarehouseSystem.Domain.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string Username { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string Address { get; set; } = null!;

		public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
		public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
		public ICollection<ProductAuditLog> ProductAuditLogs { get; set; } = new List<ProductAuditLog>();
    }
}
