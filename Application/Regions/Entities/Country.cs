using Application.Commons.Entities;

namespace Application.Regions.Entities;

public class Country : AIV_Entity
{
    public ICollection<CountryCode> CountryCodes { get; set; }
    public ICollection<Citizenship> Citizenships { get; set; }
}