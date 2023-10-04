using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
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