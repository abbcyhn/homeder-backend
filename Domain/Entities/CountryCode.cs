namespace Domain.Entities;

public class CountryCode : BaseLibEntity
{
    public int IdCountry { get; set; }

    public Country Country { get; set; }
    public ICollection<UserPhone> UserPhones { get; set; }
}