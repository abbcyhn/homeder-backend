using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Abstracts.Configs;

namespace Persistence.Users.Configs;

public class UserTypeConfig : AIV_EntityConfig<UserType>
{
    public override void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.ToTable("USER_TYPES");
    }
}