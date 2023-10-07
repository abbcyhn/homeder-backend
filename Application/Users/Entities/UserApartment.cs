using Application.Apartments.Entities;
using Application.Commons.Entities;

namespace Application.Users.Entities;

public class UserApartment : ACE_Entity
{
    public int IdUser { get; set; }
    public int IdApartment { get; set; }
    public int IdAction { get; set; }

    public User User { get; set; }
    public Apartment Apartment { get; set; }
    public UserAction UserAction { get; set; }
}