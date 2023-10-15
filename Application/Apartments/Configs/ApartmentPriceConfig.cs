﻿using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentPriceConfig : ACE_EntityConfig<ApartmentPrice>
{
    public override void Configure(EntityTypeBuilder<ApartmentPrice> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_PRICES");
        builder.HasKey(e => e.IdApartment);
        
        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.IdPriceCurrency).IsRequired();
        builder.Property(e => e.PriceExtra);
        builder.Property(e => e.IdPriceExtraCurrency);
        builder.Property(e => e.Deposit);
        builder.Property(e => e.IdDepositCurrency);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentPrice)
            .HasForeignKey<ApartmentPrice>(e => e.IdApartment);
    }
}