using Application.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Commons.Configs;

public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedBy).IsRequired();
        builder.Property(e => e.CreateDate).HasColumnType("timestamp with time zone").IsRequired();
        builder.Property(e => e.EditedBy);
        builder.Property(e => e.EditDate).HasColumnType("timestamp with time zone");
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate).HasColumnType("timestamp with time zone");
    }
}