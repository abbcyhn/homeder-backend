using Application.Commons.Configs;
using Application.Regions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Regions.Configs;

public class DistrictConfig : IdValueEntityConfig<District>
{
    public override void Configure(EntityTypeBuilder<District> builder)
    {
        base.Configure(builder);

        builder.ToTable("DISTRICTS");

        builder.HasOne(e => e.City)
            .WithMany(c => c.Districts)
            .HasForeignKey(e => e.IdCity);
    }
}