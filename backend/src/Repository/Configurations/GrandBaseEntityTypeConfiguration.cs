using Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public abstract class GrandEntityTypeConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : GrandEntity<TId>
    where TId : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(e => e.Id).IsRequired();

        builder.Property(e => e.CreatedDate).IsRequired();
    }
}
