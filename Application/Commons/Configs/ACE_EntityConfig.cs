using Application.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Commons.Configs;

public abstract class ACE_EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : ACE_Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.CreatedBy).IsRequired();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.EditedBy);
        builder.Property(e => e.EditDate);
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate);
    }
}