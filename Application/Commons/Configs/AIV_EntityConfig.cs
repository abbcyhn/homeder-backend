using Application.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Commons.Configs;

public abstract class AIV_EntityConfig<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : AIV_Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Value).IsRequired();
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate);
    }
}