using Domain.Abstracts;
using Domain.Users;

namespace Domain.Regions;

public class CountryCode : AIV_Entity
{
    public int IdCountry { get; set; }

    public Country Country { get; set; }
    public ICollection<UserPhone> UserPhones { get; set; }
}