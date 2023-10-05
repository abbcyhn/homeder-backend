using Domain.Abstracts;
using Domain.Regions;

namespace Domain.Users;

public class UserPhone : ACE_Entity
{
    public int IdUser { get; set; }
    public int? IdCountryCode { get; set; }
    public string? PhoneNumber { get; set; }
    public User? User { get; set; }
    public CountryCode? CountryCode { get; set; }
}