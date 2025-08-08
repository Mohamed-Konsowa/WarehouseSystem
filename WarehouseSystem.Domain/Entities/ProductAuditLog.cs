using WarehouseSystem.Domain.Enums;

namespace WarehouseSystem.Domain.Entities
{
	public class ProductAuditLog
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public ActionType Action { get; set; }
		public Guid ChangedByUserId { get; set; }
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;
		public string? Notes { get; set; }

		public Product Product { get; set; } = null!;
        public User ChangedByUser { get; set; } = null!;

    }
}
