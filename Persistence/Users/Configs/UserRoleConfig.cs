using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Abstracts.Configs;

namespace Persistence.Users.Configs;

public class UserRoleConfig : AIV_EntityConfig<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("USER_ROLES");
    }
}