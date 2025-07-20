
namespace WarehouseSystem.Domain.Entities
{
	public enum ActionType
	{
		Created,
		Updated,
		Deleted
	}
	public class ProductAuditLog
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public ActionType Action { get; set; }
		public string? ChangedByUserId { get; set; }
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;
		public string? Notes { get; set; }

	}
}
