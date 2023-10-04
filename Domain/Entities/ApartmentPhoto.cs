namespace Domain.Entities;

public class ApartmentPhoto : BaseEntity
{
    public int IdApartment { get; set; }
    public string PhotoUrl { get; set; }

    public Apartment Apartment { get; set; }
}