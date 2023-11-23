using Application.Commons.Configs;
using Application.Regions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Regions.Configs;

public class StateConfig : IdValueEntityConfig<State>
{
    public override void Configure(EntityTypeBuilder<State> builder)
    {
        base.Configure(builder);

        builder.ToTable("STATES");

        builder.HasOne(e => e.Country)
            .WithMany(c => c.States)
            .HasForeignKey(e => e.IdCountry);
    }
}