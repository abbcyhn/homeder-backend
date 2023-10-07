using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserRoleConfig : AIV_EntityConfig<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("USER_ROLES");
    }
}