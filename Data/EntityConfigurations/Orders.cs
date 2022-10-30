using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStoreWeb.Data.Entities;

namespace SimpleStoreWeb.Data.EntityConfigurations
{
    internal class Orders : EntityTypeConfiguration<Order>
    {
        public override void BuildEntityType(EntityTypeBuilder<Order> orders)
        {
            orders.ToTable("orders", SimpleStoreDbContext.DefaultSchema);

            orders.Property(x => x.Name);

            orders.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order);

            orders.HasIndex(x => new { x.Name, x.ApplicationUserId }).IsUnique();
        }
    }
}