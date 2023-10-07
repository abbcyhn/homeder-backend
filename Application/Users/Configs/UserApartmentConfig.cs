using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserApartmentConfig : ACE_EntityConfig<UserApartment>
{
    public override void Configure(EntityTypeBuilder<UserApartment> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_APARTMENTS");
        builder.HasKey(e => new { e.IdUser, e.IdApartment, e.IdAction });
        builder.Property(e => e.IdAction).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(u => u.UserApartments)
            .HasForeignKey(e => e.IdUser);

        builder.HasOne(e => e.Apartment)
            .WithMany(a => a.UserApartments)
            .HasForeignKey(e => e.IdApartment);

        builder.HasOne(e => e.UserAction)
            .WithMany()
            .HasForeignKey(e => e.IdAction);
    }
}