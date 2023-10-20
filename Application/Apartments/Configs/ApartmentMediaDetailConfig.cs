using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentMediaDetailConfig : BaseEntityConfig<ApartmentMediaDetail>
{
    public override void Configure(EntityTypeBuilder<ApartmentMediaDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_MEDIA_DETAILS");

        builder.Property(e => e.HasCableTv);
        builder.Property(e => e.HasSatelliteTv);
        builder.Property(e => e.HasInternet);
        builder.Property(e => e.HasPhone);
        builder.Property(e => e.HasIntercom);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentMediaDetail)
            .HasForeignKey<ApartmentMediaDetail>(e => e.IdApartment);
    }
}