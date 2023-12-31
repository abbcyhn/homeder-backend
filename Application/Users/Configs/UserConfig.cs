﻿using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserConfig : BaseEntityConfig<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("USERS");

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Surname).IsRequired();
        builder.Property(e => e.Birthdate).HasColumnType("date");
        builder.Property(e => e.PhotoUrl);
        builder.Property(e => e.IdRole).IsRequired();

        builder.HasOne(e => e.UserRole)
            .WithMany()
            .HasForeignKey(e => e.IdRole);
    }
}