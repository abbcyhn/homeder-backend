using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserActionConfig : IdValueEntityConfig<UserAction>
{
    public override void Configure(EntityTypeBuilder<UserAction> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_ACTIONS");
    }
}