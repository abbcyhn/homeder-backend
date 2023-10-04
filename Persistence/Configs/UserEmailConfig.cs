using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class UserEmailConfig : BaseEntityConfig<UserEmail>
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