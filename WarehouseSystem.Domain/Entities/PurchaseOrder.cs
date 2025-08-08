using WarehouseSystem.Domain.Enums;

namespace WarehouseSystem.Domain.Entities
{
	public class PurchaseOrder
	{
		public Guid Id { get; set; }
		public Guid SupplierId { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		public OrderStatus Status { get; set; } = OrderStatus.Pending; // Approved, Cancelled, Completed

        public Supplier Supplier { get; set; } = null!;
        public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
    }
}
