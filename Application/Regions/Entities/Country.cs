using Application.Commons.Entities;
using Application.Regions.Entities;

namespace Application.Regions.Configs;

public class Country : AIV_Entity
{
    public ICollection<CountryCode> CountryCodes { get; set; }
    public ICollection<Citizenship> Citizenships { get; set; }
}