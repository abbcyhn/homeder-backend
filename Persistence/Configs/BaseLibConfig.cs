using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class BaseLibConfig<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : BaseLibEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Value).IsRequired();
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate);
    }
}