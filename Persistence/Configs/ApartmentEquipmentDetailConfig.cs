using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class ApartmentEquipmentDetailConfig : BaseEntityConfig<ApartmentEquipmentDetail>
{
    public override void Configure(EntityTypeBuilder<ApartmentEquipmentDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_EQUIPMENT_DETAILS");
        builder.HasKey(e => e.IdApartment);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentEquipmentDetail)
            .HasForeignKey<ApartmentEquipmentDetail>(e => e.IdApartment);
    }
}