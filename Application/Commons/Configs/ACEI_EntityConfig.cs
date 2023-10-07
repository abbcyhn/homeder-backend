using Application.Commons.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Commons.Configs;

public abstract class ACEI_EntityConfig<TEntity> : ACE_EntityConfig<TEntity> where TEntity : ACEI_Entity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);
    }
}