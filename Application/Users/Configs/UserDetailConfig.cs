using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserDetailConfig : BaseEntityConfig<UserDetail>
{
    public override void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("USER_DETAILS");

        builder.Property(e => e.IdUserType).IsRequired();
        builder.Property(e => e.IdCitizenship).IsRequired();
        builder.Property(e => e.NoOfPeople).IsRequired();
        builder.Property(e => e.IsSmoker).IsRequired();
        builder.Property(e => e.HasChild).IsRequired();
        builder.Property(e => e.HasPet).IsRequired();
        builder.Property(e => e.HasBankStatement).IsRequired();
        builder.Property(e => e.HasWorkContract).IsRequired();
        builder.Property(e => e.HasWorkPermit).IsRequired();
        builder.Property(e => e.HasUmowaOkazionalny).IsRequired();

        builder.HasOne(e => e.User)
            .WithOne(u => u.UserDetail)
            .HasForeignKey<UserDetail>(e => e.IdUser);

        builder.HasOne(e => e.UserType)
            .WithMany()
            .HasForeignKey(e => e.IdUserType);

        builder.HasOne(e => e.Citizenship)
            .WithMany()
            .HasForeignKey(e => e.IdCitizenship);
    }
}