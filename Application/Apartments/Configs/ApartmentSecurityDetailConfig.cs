using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentSecurityDetailConfig : BaseEntityConfig<ApartmentSecurityDetail>
{
    public override void Configure(EntityTypeBuilder<ApartmentSecurityDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_SECURITY_DETAILS");

        builder.Property(e => e.HasAlarmSystem);
        builder.Property(e => e.HasSecurityDoors);
        builder.Property(e => e.HasCCTV);
        builder.Property(e => e.HasConcierge);
        builder.Property(e => e.HasSecurityShutters);
        builder.Property(e => e.HasFireAlarm);
        builder.Property(e => e.HasSmokeDetectors);
        builder.Property(e => e.HasGasDetectors);
        builder.Property(e => e.HasFloodDetectors);
        builder.Property(e => e.HasSafeRoom);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentSecurityDetail)
            .HasForeignKey<ApartmentSecurityDetail>(e => e.IdApartment);
    }
}