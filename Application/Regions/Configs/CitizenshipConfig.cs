using Application.Commons.Configs;
using Application.Regions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Regions.Configs;

public class CitizenshipConfig : AIV_EntityConfig<Citizenship>
{
    public override void Configure(EntityTypeBuilder<Citizenship> builder)
    {
        base.Configure(builder);

        builder.ToTable("CITIZENSHIPS");

        builder.HasOne(e => e.Country)
            .WithMany(c => c.Citizenships)
            .HasForeignKey(e => e.IdCountry);
    }
}