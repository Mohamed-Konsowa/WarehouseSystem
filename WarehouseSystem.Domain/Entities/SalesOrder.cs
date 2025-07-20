
namespace WarehouseSystem.Domain.Entities
{
	public class SalesOrder
	{
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		public OrderStatus Status { get; set; } = OrderStatus.Pending;  // Delivered, Cancelled, etc.

	}
}
