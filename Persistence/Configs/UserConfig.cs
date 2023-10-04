using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class UserConfig : BaseEntityConfig<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("USERS");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Surname).IsRequired();
        builder.Property(e => e.Birthdate);
        builder.Property(e => e.PhotoUrl);
        builder.Property(e => e.IdRole).IsRequired();
        builder.Property(e => e.IdCitizenship).IsRequired();

        builder.HasOne(e => e.UserRole)
            .WithMany()
            .HasForeignKey(e => e.IdRole);

        builder.HasOne(e => e.Citizenship)
            .WithMany()
            .HasForeignKey(e => e.IdCitizenship);
    }
}