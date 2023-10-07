using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserPhoneConfig : ACE_EntityConfig<UserPhone>
{
    public override void Configure(EntityTypeBuilder<UserPhone> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_PHONES");
        builder.HasKey(e => new { e.IdUser, e.PhoneNumber });
        builder.Property(e => e.PhoneNumber).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(u => u.UserPhones)
            .HasForeignKey(e => e.IdUser);

        builder.HasOne(e => e.CountryCode)
            .WithMany(cc => cc.UserPhones)
            .HasForeignKey(e => e.IdCountryCode);
    }
}