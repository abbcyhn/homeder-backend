using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentPhotoConfig : ACE_EntityConfig<ApartmentPhoto>
{
    public override void Configure(EntityTypeBuilder<ApartmentPhoto> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_PHOTOS");
        builder.HasKey(e => new { e.IdApartment, e.PhotoUrl });
        builder.Property(e => e.PhotoUrl).IsRequired();

        builder.HasOne(e => e.Apartment)
            .WithMany(a => a.ApartmentPhotos)
            .HasForeignKey(e => e.IdApartment);
    }
}