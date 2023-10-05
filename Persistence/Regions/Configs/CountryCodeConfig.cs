using Domain.Regions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Abstracts.Configs;

namespace Persistence.Regions.Configs;

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