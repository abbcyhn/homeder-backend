namespace Domain.Entities;

public class UserPhone : BaseEntity
{
    public int IdUser { get; set; }
    public int? IdCountryCode { get; set; }
    public string? PhoneNumber { get; set; }
    public User? User { get; set; }
    public CountryCode? CountryCode { get; set; }
}