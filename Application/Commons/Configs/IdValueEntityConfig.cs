using Application.Commons.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Commons.Configs;

public abstract class IdValueEntityConfig<TEntity>: BaseEntityConfig<TEntity> where TEntity : IdValueEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Value).IsRequired();
    }
}