using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStoreWeb.Data.Entities;

namespace SimpleStoreWeb.Data.EntityConfigurations
{
    internal class OrderItems : EntityTypeConfiguration<OrderItem>
    {
        public override void BuildEntityType(EntityTypeBuilder<OrderItem> orderItems)
        {
            orderItems.ToTable("order_items", SimpleStoreDbContext.DefaultSchema);
            orderItems.Property(x => x.IsPurchased);

            orderItems
                .HasOne(e => e.Product)
                .WithMany(c => c.OrderItems);

            orderItems.HasIndex(x => new { x.OrderId, x.ProductId }).IsUnique();
        }
    }
}