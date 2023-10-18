using Application.Commons.Entities;

namespace Application.Users.Entities;

public class UserEmail : BaseEntity
{
    public int IdUser { get; set; }
    public string Email { get; set; }
    public bool IsVerified { get; set; }

    public User User { get; set; }
}