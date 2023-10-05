using Domain.Abstracts;

namespace Domain.Apartments;

public class ApartmentPhoto : ACE_Entity
{
    public int IdApartment { get; set; }
    public string PhotoUrl { get; set; }

    public Apartment Apartment { get; set; }
}