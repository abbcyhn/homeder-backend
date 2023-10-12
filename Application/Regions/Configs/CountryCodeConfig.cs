using Application.Commons.Configs;
using Application.Regions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Regions.Configs;

public class CountryCodeConfig : AIV_EntityConfig<CountryCode>
{
    public override void Configure(EntityTypeBuilder<CountryCode> builder)
    {
        base.Configure(builder);

        builder.ToTable("COUNTRY_CODES");

        builder.HasOne(e => e.Country)
            .WithMany(c => c.CountryCodes)
            .HasForeignKey(e => e.IdCountry);
    }
}