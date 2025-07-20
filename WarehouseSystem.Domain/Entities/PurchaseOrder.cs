
namespace WarehouseSystem.Domain.Entities
{
	public enum OrderStatus
	{
		Pending,
		Approved,
		Cancelled,
		Completed
	}
	public class PurchaseOrder
	{
		public Guid Id { get; set; }
		public Guid SupplierId { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		public OrderStatus Status { get; set; } = OrderStatus.Pending; // Approved, Cancelled, Completed

	}
}
