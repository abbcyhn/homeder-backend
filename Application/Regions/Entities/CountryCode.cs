using Application.Commons.Entities;
using Application.Users.Entities;

namespace Application.Regions.Entities;

public class CountryCode : AIV_Entity
{
    public int IdCountry { get; set; }

    public Country Country { get; set; }
    public ICollection<UserPhone> UserPhones { get; set; }
}