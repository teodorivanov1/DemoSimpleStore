using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStoreWeb.Data.Entities;

namespace SimpleStoreWeb.Data.EntityConfigurations
{
    public class ApplicationUsers : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.Products)
                .WithOne()
                .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
