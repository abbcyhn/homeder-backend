using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class CountryConfig : BaseLibConfig<Country>
{
    public override void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("COUNTRIES");

        builder.HasMany(e => e.CountryCodes)
            .WithOne(cc => cc.Country)
            .HasForeignKey(cc => cc.IdCountry);

        builder.HasMany(e => e.Citizenships)
            .WithOne(c => c.Country)
            .HasForeignKey(c => c.IdCountry);
    }
}