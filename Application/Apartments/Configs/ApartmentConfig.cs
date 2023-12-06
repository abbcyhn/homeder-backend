using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentConfig : BaseEntityConfig<Apartment>
{
    public override void Configure(EntityTypeBuilder<Apartment> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENTS");
        
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Area).IsRequired();
        builder.Property(e => e.NoOfRooms).IsRequired();
        builder.Property(e => e.Description);
        builder.Property(e => e.IdCountry).IsRequired();
        builder.Property(e => e.IdState).IsRequired();
        builder.Property(e => e.IdCity).IsRequired();
        builder.Property(e => e.IdDistrict).IsRequired();
        builder.Property(e => e.StreetName).IsRequired();
        builder.Property(e => e.Latitude).IsRequired();
        builder.Property(e => e.Longtitude).IsRequired();
        builder.Property(e => e.IdAdvertiserType).IsRequired();

        builder.HasOne(e => e.Country)
            .WithMany(c => c.Apartments)
            .HasForeignKey(e => e.IdCountry);

        builder.HasOne(e => e.State)
            .WithMany(c => c.Apartments)
            .HasForeignKey(e => e.IdState);

        builder.HasOne(e => e.City)
            .WithMany(c => c.Apartments)
            .HasForeignKey(e => e.IdCity);

        builder.HasOne(e => e.District)
            .WithMany(c => c.Apartments)
            .HasForeignKey(e => e.IdDistrict);
    }
}