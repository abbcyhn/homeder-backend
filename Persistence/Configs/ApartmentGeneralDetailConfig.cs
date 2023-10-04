using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configs;

public class ApartmentGeneralDetailConfig : BaseEntityConfig<ApartmentGeneralDetail>
{
    public override void Configure(EntityTypeBuilder<ApartmentGeneralDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_GENERAL_DETAILS");
        builder.HasKey(e => e.IdApartment);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentGeneralDetail)
            .HasForeignKey<ApartmentGeneralDetail>(e => e.IdApartment);
    }
}