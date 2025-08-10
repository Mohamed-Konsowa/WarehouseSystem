using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystem.Domain.Entities;

namespace WarehouseSystem.Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(r => r.Username).IsUnique();
            builder.HasIndex(r => r.Phone).IsUnique();
            builder.HasIndex(r => r.Email).IsUnique();
        }
    }
}


