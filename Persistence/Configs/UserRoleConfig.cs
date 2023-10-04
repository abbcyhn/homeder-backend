using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class UserRoleConfig : BaseLibConfig<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("USER_ROLES");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Value).IsRequired();
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate);
    }
}