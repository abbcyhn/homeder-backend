using Application.Apartments.Entities;
using Application.Commons.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Apartments.Configs;

public class ApartmentTenantDetailConfig : BaseEntityConfig<ApartmentTenantDetail>
{
    public override void Configure(EntityTypeBuilder<ApartmentTenantDetail> builder)
    {
        base.Configure(builder);

        builder.ToTable("APARTMENT_TENANT_DETAILS");

        builder.Property(e => e.AllowsSmoking);
        builder.Property(e => e.AllowsPets);
        builder.Property(e => e.AllowsChildren);
        builder.Property(e => e.AllowsStudents);
        builder.Property(e => e.AllowsForeigners);
        builder.Property(e => e.AllowsShortTerm);
        builder.Property(e => e.AllowsLongTerm);

        builder.HasOne(e => e.Apartment)
            .WithOne(a => a.ApartmentTenantDetail)
            .HasForeignKey<ApartmentTenantDetail>(e => e.IdApartment);
    }
}