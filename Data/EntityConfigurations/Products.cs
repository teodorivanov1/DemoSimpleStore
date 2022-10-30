using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStoreWeb.Data.Entities;

namespace SimpleStoreWeb.Data.EntityConfigurations
{
    internal class Products : EntityTypeConfiguration<Product>
    {
        public override void BuildEntityType(EntityTypeBuilder<Product> products)
        {
            products.ToTable("products", SimpleStoreDbContext.DefaultSchema);
            products.Property(x => x.Name);
            products.Property(x => x.Description);
            products.Property(x => x.Price);
            products.Property(x => x.ImagePath);

            // this index must be case insensitive
            products.HasIndex(a => new { a.ApplicationUserId, a.Name, a.CategoryId }).IsUnique();
        }
    }
}
