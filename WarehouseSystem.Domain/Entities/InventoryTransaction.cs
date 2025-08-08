using WarehouseSystem.Domain.Enums;

namespace WarehouseSystem.Domain.Entities
{
	public class InventoryTransaction
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public TransactionType Type { get; set; }
		public int Quantity { get; set; }
		public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
		public string? Note { get; set; }

		public Product Product { get; set; } = null!;
	}
}
