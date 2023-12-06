using Application.Commons.Configs;
using Application.Regions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Regions.Configs;

public class CityConfig : IdValueEntityConfig<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        base.Configure(builder);

        builder.ToTable("CITIES");

        builder.HasOne(e => e.State)
            .WithMany(c => c.Cities)
            .HasForeignKey(e => e.IdState);
    }
}