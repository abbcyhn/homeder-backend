using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class ApartmentAdditionalDetailConfig : BaseEntityConfig<ApartmentAdditionalDetail>
{
    public override void Configure(EntityTypeBuilder<ApartmentAdditionalDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_ADDITIONAL_DETAILS");
        builder.HasKey(e => e.IdApartment);

        builder.Property(e => e.HasStorage);
        builder.Property(e => e.HasCellar);
        builder.Property(e => e.HasAttic);
        builder.Property(e => e.HasGarage);
        builder.Property(e => e.HasParkingSpace);
        builder.Property(e => e.HasGarden);
        builder.Property(e => e.HasBalcony);
        builder.Property(e => e.HasTerrace);
        builder.Property(e => e.HasFireplace);
        builder.Property(e => e.HasPool);
        builder.Property(e => e.HasSauna);
        builder.Property(e => e.HasGym);
        builder.Property(e => e.HasPlayground);
        builder.Property(e => e.HasBBQArea);
        builder.Property(e => e.HasLaundryRoom);
        builder.Property(e => e.HasBikeStorage);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentAdditionalDetail)
            .HasForeignKey<ApartmentAdditionalDetail>(e => e.IdApartment);
    }
}