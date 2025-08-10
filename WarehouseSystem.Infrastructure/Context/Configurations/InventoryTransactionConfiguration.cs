using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Infrastructure.Context.Configurations
{
    internal class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
    {
        public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
        {
            builder.ToTable("InventoryTransactions");
            builder.HasKey(i => i.Id);
            builder.Property(e => e.Quantity)
                .IsRequired()
                .HasDefaultValue(0);
            builder.HasOne(i => i.Product)
                .WithMany(p => p.InventoryTransactions)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
