
namespace WarehouseSystem.Domain.Entities
{
	public class SalesOrderItem
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		public SalesOrder Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
