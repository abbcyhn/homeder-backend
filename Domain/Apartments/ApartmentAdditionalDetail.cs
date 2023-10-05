using Domain.Abstracts;

namespace Domain.Apartments;

public class ApartmentAdditionalDetail : ACE_Entity
{
    public int IdApartment { get; set; }
    public bool? HasStorage { get; set; }
    public bool? HasCellar { get; set; }
    public bool? HasAttic { get; set; }
    public bool? HasGarage { get; set; }
    public bool? HasParkingSpace { get; set; }
    public bool? HasGarden { get; set; }
    public bool? HasBalcony { get; set; }
    public bool? HasTerrace { get; set; }
    public bool? HasFireplace { get; set; }
    public bool? HasPool { get; set; }
    public bool? HasSauna { get; set; }
    public bool? HasGym { get; set; }
    public bool? HasPlayground { get; set; }
    public bool? HasBBQArea { get; set; }
    public bool? HasLaundryRoom { get; set; }
    public bool? HasBikeStorage { get; set; }

    public Apartment Apartment { get; set; }
}