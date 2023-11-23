using Application.Commons.Entities;
using Application.Regions.Entities;
using Application.Users.Entities;

namespace Application.Apartments.Entities;

public class Apartment : BaseEntity
{
    public string Title { get; set; }
    public decimal Area { get; set; }
    public int NoOfRooms { get; set; }
    public string Description { get; set; }
    public int IdCountry { get; set; }
    public int IdState { get; set; }
    public int IdCity { get; set; }
    public int IdDistrict { get; set; }
    public string StreetName { get; set; }
    public string Latitude { get; set; }
    public string Longtitude { get; set; }
    public int IdAdvertiserType { get; set; }

    public Country Country { get; set; }
    public State State { get; set; }
    public City City { get; set; }
    public District District { get; set; }

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