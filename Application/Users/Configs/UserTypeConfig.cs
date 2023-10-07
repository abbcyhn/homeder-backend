using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserTypeConfig : AIV_EntityConfig<UserType>
{
    public override void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.ToTable("USER_TYPES");
    }
}