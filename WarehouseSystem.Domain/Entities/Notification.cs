
namespace WarehouseSystem.Domain.Entities
{
	public class Notification
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = null!;
		public string Message { get; set; } = null!;
		public Guid UserId { get; set; }
		public bool IsRead { get; set; } = false;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	}
}
