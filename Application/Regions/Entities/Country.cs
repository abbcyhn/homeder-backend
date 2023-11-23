using Application.Commons.Entities;

namespace Application.Regions.Entities;

public class Country : IdValueEntity
{
    public ICollection<State> States { get; set; }
    public ICollection<CountryCode> CountryCodes { get; set; }
    public ICollection<Citizenship> Citizenships { get; set; }
}