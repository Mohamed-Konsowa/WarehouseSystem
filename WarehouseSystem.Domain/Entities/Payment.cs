
namespace WarehouseSystem.Domain.Entities
{
	public class Payment
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public decimal Amount { get; set; }
		public string Method { get; set; } = "Cash"; // Cash, Credit, Transfer, etc.
		public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

	}
}
