
namespace WarehouseSystem.Domain.Entities
{
	public class Supplier
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Address { get; set; } = null!;

		public ICollection<Product> Products { get; set; } = new List<Product>();

	}
}
