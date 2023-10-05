using Domain.Abstracts;
using Domain.Users;

namespace Domain.Apartments;

public class Apartment : ACEI_Entity
{
    public string Title { get; set; }
    public decimal Area { get; set; }
    public int NoOfRooms { get; set; }
    public string Description { get; set; }
    public int IdCity { get; set; }
    public int IdDistrict { get; set; }
    public int IdStreet { get; set; }
    public int IdAdvertiserType { get; set; }

    public ICollection<UserApartment> UserApartments { get; set; }
    public ApartmentPrice ApartmentPrice { get; set; }
    public ICollection<ApartmentPhoto> ApartmentPhotos { get; set; }
    public ApartmentGeneralDetail ApartmentGeneralDetail { get; set; }
    public ApartmentEquipmentDetail ApartmentEquipmentDetail { get; set; }
    public ApartmentSecurityDetail ApartmentSecurityDetail { get; set; }
    public ApartmentMediaDetail ApartmentMediaDetail { get; set; }
    public ApartmentAdditionalDetail ApartmentAdditionalDetail { get; set; }
    public ApartmentTenantDetail ApartmentTenantDetail { get; set; }
}