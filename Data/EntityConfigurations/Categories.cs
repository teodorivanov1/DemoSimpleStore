using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStoreWeb.Data.Entities;

namespace SimpleStoreWeb.Data.EntityConfigurations
{
    internal class Categories : EntityTypeConfiguration<Category>
    {
        public override void BuildEntityType(EntityTypeBuilder<Category> categories)
        {
            categories.ToTable("categories", SimpleStoreDbContext.DefaultSchema);
            categories.Property(x => x.Name);

            categories.HasMany(c => c.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(p => p.CategoryId);

            // this index must be case insensitive
            categories.HasIndex(u => u.Name).IsUnique();
        }
    }
}