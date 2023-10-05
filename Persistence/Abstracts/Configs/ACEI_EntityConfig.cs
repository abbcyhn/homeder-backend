using Domain.Abstracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Abstracts.Configs;

public abstract class ACEI_EntityConfig<TEntity> : ACE_EntityConfig<TEntity> where TEntity : ACEI_Entity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);
    }
}