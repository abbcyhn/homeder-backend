namespace Domain.Entities;

public class ApartmentMediaDetail : BaseEntity
{
    public int IdApartment { get; set; }
    public bool? HasCableTv { get; set; }
    public bool? HasSatelliteTv { get; set; }
    public bool? HasInternet { get; set; }
    public bool? HasPhone { get; set; }
    public bool? HasIntercom { get; set; }

    public Apartment Apartment { get; set; }
}