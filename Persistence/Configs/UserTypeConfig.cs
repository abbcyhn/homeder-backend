using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class UserTypeConfig : BaseLibConfig<UserType>
{
    public override void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.ToTable("USER_TYPES");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Value).IsRequired();
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate);
    }
}