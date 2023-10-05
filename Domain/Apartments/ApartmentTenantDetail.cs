using Domain.Abstracts;

namespace Domain.Apartments;

public class ApartmentTenantDetail : ACE_Entity
{
    public int IdApartment { get; set; }
    public bool? AllowsSmoking { get; set; }
    public bool? AllowsPets { get; set; }
    public bool? AllowsChildren { get; set; }
    public bool? AllowsStudents { get; set; }
    public bool? AllowsForeigners { get; set; }
    public bool? AllowsShortTerm { get; set; }
    public bool? AllowsLongTerm { get; set; }

    public Apartment Apartment { get; set; }
}