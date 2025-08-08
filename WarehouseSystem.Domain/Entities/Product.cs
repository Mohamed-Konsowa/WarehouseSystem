namespace WarehouseSystem.Domain.Entities
{
	public class Product
	{
		public Guid Id { get; set; }
		public Guid CategoryId { get; set; }
		public Guid SupplierId { get; set; }
		public Guid WarehouseId { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public string SKU { get; set; } = null!; // Unique Stock Keeping Unit
		public string? Barcode { get; set; }
		public int QuantityInStock { get; set; }
		public string? ImageUrl { get; set; }

		public Category Category { get; set; } = null!;
		public Supplier Supplier { get; set; } = null!;
		public Warehouse Warehouse { get; set; } = null!;
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
        public ICollection<ProductAuditLog> ProductAuditLogs { get; set; } = new List<ProductAuditLog>();
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();

    }
}
