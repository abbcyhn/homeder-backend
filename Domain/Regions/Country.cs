using Domain.Abstracts;

namespace Domain.Regions;

public class Country : AIV_Entity
{
    public ICollection<CountryCode> CountryCodes { get; set; }
    public ICollection<Citizenship> Citizenships { get; set; }
}