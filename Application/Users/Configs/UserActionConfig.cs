using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserActionConfig : AIV_EntityConfig<UserAction>
{
    public override void Configure(EntityTypeBuilder<UserAction> builder)
    {
        builder.ToTable("USER_ACTIONS");
    }
}