using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class CountryCodeConfig : BaseLibConfig<CountryCode>
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