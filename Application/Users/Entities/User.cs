using Application.Commons.Entities;

namespace Application.Users.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? Birthdate { get; set; }
    public string? PhotoUrl { get; set; }
    public int IdRole { get; set; }

    public UserRole UserRole { get; set; }
    public ICollection<UserEmail> UserEmails { get; set; }
    public ICollection<UserPhone> UserPhones { get; set; }
    public ICollection<UserApartment> UserApartments { get; set; }
    public UserDetail UserDetail { get; set; }
}