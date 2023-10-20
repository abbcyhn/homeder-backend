using Application.Commons.Mediator;
using Application.Users.Enums;

namespace Application.Users.Features.UpdateUser;

public record UpdateUserInput : BaseInput
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public int PhoneCountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public int Citizenship { get; set; }
    public int NumberOfPeople { get; set; }
    public UserType UserType { get; set; }
    public UserRole UserRole { get; set; }
    public bool IsSmoker { get; set; }
    public bool HasChild { get; set; }
    public bool HasPet { get; set; }
    public bool HasBankStatement { get; set; }
    public bool HasWorkContract { get; set; }
    public bool HasWorkPermit { get; set; }
    public bool HasUmowaOkazionalny { get; set; }
}