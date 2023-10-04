using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class UserDetailsConfig : BaseEntityConfig<UserDetails>
{
    public override void Configure(EntityTypeBuilder<UserDetails> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_DETAILS");
        builder.HasKey(e => e.IdUser);
        builder.Property(e => e.IdUserType).IsRequired();
        builder.Property(e => e.NoOfPeople).IsRequired();
        builder.Property(e => e.IsSmoker).IsRequired();
        builder.Property(e => e.HasChild).IsRequired();
        builder.Property(e => e.HasPet).IsRequired();
        builder.Property(e => e.HasBankStatement).IsRequired();
        builder.Property(e => e.HasWorkContract).IsRequired();
        builder.Property(e => e.HasWorkPermit).IsRequired();
        builder.Property(e => e.HasUmowaOkazionalny).IsRequired();

        builder.HasOne(e => e.User)
            .WithOne(u => u.UserDetails)
            .HasForeignKey<UserDetails>(e => e.IdUser);

        builder.HasOne(e => e.UserType)
            .WithMany()
            .HasForeignKey(e => e.IdUserType);
    }
}