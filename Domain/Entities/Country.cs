namespace Domain.Entities;

public class Country : BaseLibEntity
{
    public ICollection<CountryCode> CountryCodes { get; set; }
    public ICollection<Citizenship> Citizenships { get; set; }
}