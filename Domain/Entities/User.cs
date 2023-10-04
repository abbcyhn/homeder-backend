namespace Domain.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? Birthdate { get; set; }
    public string PhotoUrl { get; set; }
    public int IdRole { get; set; }
    public int IdCitizenship { get; set; }

    public UserRole UserRole { get; set; }
    public Citizenship Citizenship { get; set; }
    public ICollection<UserEmail> UserEmails { get; set; }
    public ICollection<UserPhone> UserPhones { get; set; }
    public ICollection<UserApartment> UserApartments { get; set; }
    public UserDetails UserDetails { get; set; }
}