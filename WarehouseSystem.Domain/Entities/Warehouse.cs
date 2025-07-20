namespace WarehouseSystem.Domain.Entities
{
	public class Warehouse
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public string Location { get; set; } = null!;
	}
}
