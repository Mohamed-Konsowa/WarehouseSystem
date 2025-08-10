using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Infrastructure.Context.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasIndex(r => r.Phone).IsUnique();
            builder.HasIndex(r => r.Email).IsUnique();
        }
    }
}


