namespace Domain.Entities;

public class UserEmail : BaseEntity
{
    public int IdUser { get; set; }
    public string Email { get; set; }

    public User User { get; set; }
}