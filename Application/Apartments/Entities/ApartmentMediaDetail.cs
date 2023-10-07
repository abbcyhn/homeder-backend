using Application.Commons.Entities;

namespace Application.Apartments.Entities;

public class ApartmentMediaDetail : ACE_Entity
{
    public int IdApartment { get; set; }
    public bool? HasCableTv { get; set; }
    public bool? HasSatelliteTv { get; set; }
    public bool? HasInternet { get; set; }
    public bool? HasPhone { get; set; }
    public bool? HasIntercom { get; set; }

    public Apartment Apartment { get; set; }
}