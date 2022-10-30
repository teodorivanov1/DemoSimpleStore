using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStoreWeb.Data.Entities.Abstraction;

namespace SimpleStoreWeb.Data.EntityConfigurations
{
    internal abstract class EntityTypeConfiguration<TCandidate> : IEntityTypeConfiguration<TCandidate>
    where TCandidate : Entity
    {
        public void Configure(EntityTypeBuilder<TCandidate> builder)
        {
            builder.HasKey(x => x.Id);
            BuildEntityType(builder);
        }

        public abstract void BuildEntityType(EntityTypeBuilder<TCandidate> builder);
    }
}
