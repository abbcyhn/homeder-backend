using Domain.Abstracts;

namespace Domain.Users;

public class UserEmail : ACE_Entity
{
    public int IdUser { get; set; }
    public string Email { get; set; }

    public User User { get; set; }
}