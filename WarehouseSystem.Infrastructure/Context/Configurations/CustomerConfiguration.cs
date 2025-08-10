using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Infrastructure.Context.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(60);
            builder.HasIndex(c => c.Email)
                .IsUnique();
            builder.HasMany(c => c.SalesOrders)
                .WithOne(so => so.Customer)
                .HasForeignKey(so => so.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
