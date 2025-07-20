
namespace WarehouseSystem.Domain.Entities
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public string SKU { get; set; } = null!; // Unique Stock Keeping Unit
		public string? Barcode { get; set; }
		public int QuantityInStock { get; set; }
		public string? ImageUrl { get; set; }

	}
}
