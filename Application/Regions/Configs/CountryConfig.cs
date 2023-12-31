﻿using Application.Commons.Configs;
using Application.Regions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Regions.Configs;

public class CountryConfig : IdValueEntityConfig<Country>
{
    public override void Configure(EntityTypeBuilder<Country> builder)
    {
        base.Configure(builder);

        builder.ToTable("COUNTRIES");

        builder.HasMany(e => e.CountryCodes)
            .WithOne(cc => cc.Country)
            .HasForeignKey(cc => cc.IdCountry);

        builder.HasMany(e => e.Citizenships)
            .WithOne(c => c.Country)
            .HasForeignKey(c => c.IdCountry);
    }
}