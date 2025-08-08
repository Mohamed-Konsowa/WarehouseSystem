using WarehouseSystem.Domain.Enums;

namespace WarehouseSystem.Domain.Entities
{
	public class PurchasePayment
    {
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public decimal Amount { get; set; }
		public PaymentMethod Method { get; set; } = PaymentMethod.Cash;
		public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

		public PurchaseOrder Order { get; set; } = null!;
    }
}
