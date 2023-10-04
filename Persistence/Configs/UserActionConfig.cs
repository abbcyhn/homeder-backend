using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class UserActionConfig : BaseLibConfig<UserAction>
{
    public override void Configure(EntityTypeBuilder<UserAction> builder)
    {
        builder.ToTable("USER_ACTIONS");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Value).IsRequired();
        builder.Property(e => e.ArchivedBy);
        builder.Property(e => e.ArchivedDate);
    }
}