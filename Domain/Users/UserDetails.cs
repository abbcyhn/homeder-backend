using Domain.Abstracts;

namespace Domain.Users;

public class UserDetails : ACE_Entity
{
    public int IdUser { get; set; }
    public int IdUserType { get; set; }
    public int NoOfPeople { get; set; }
    public bool IsSmoker { get; set; }
    public bool HasChild { get; set; }
    public bool HasPet { get; set; }
    public bool HasBankStatement { get; set; }
    public bool HasWorkContract { get; set; }
    public bool HasWorkPermit { get; set; }
    public bool HasUmowaOkazionalny { get; set; }

    public User User { get; set; }
    public UserType UserType { get; set; }
}