using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class CitizenshipConfig : BaseLibConfig<Citizenship>
{
    public override void Configure(EntityTypeBuilder<Citizenship> builder)
    {
        base.Configure(builder);

        builder.ToTable("CITIZENSHIPS");
        builder.Property(e => e.Value).IsRequired();

        builder.HasOne(e => e.Country)
            .WithMany(c => c.Citizenships)
            .HasForeignKey(e => e.IdCountry);
    }
}