using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Abstracts.Configs;

namespace Persistence.Users.Configs;

public class UserEmailConfig : ACE_EntityConfig<UserEmail>
{
    public override void Configure(EntityTypeBuilder<UserEmail> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_EMAILS");
        builder.HasKey(e => new { e.IdUser, e.Email });
        builder.Property(e => e.Email).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(u => u.UserEmails)
            .HasForeignKey(e => e.IdUser);
    }
}