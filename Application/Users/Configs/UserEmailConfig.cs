using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserEmailConfig : BaseEntityConfig<UserEmail>
{
    public override void Configure(EntityTypeBuilder<UserEmail> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_EMAILS");

        builder.Property(e => e.Email).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(u => u.UserEmails)
            .HasForeignKey(e => e.IdUser);
    }
}