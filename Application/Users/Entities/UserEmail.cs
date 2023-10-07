using Application.Commons.Entities;

namespace Application.Users.Entities;

public class UserEmail : ACE_Entity
{
    public int IdUser { get; set; }
    public string Email { get; set; }

    public User User { get; set; }
}