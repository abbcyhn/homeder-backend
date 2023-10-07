using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentConfig : ACEI_EntityConfig<Apartment>
{
    public override void Configure(EntityTypeBuilder<Apartment> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENTS");
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Area).IsRequired();
        builder.Property(e => e.NoOfRooms).IsRequired();
        builder.Property(e => e.Description);
        builder.Property(e => e.IdCity).IsRequired();
        builder.Property(e => e.IdDistrict).IsRequired();
        builder.Property(e => e.IdStreet).IsRequired();
        builder.Property(e => e.IdAdvertiserType).IsRequired();
    }
}