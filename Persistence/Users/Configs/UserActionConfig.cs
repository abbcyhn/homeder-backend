using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Abstracts.Configs;

namespace Persistence.Users.Configs;

public class UserActionConfig : AIV_EntityConfig<UserAction>
{
    public override void Configure(EntityTypeBuilder<UserAction> builder)
    {
        builder.ToTable("USER_ACTIONS");
    }
}