using Application.Commons.Mediator;

namespace Application.Users.Features.UpdateUser;

public record UpdateUserRequest : BaseRequest<UpdateUserResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Email { get; set; }
    public int PhoneCountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public int IdCitizenship { get; set; }
    public int NumberOfPeople { get; set; }
    public int IdUserType { get; set; }
    public int IdRole { get; set; }
    public bool IsSmoker { get; set; }
    public bool HasChild { get; set; }
    public bool HasPet { get; set; }
    public bool HasBankStatement { get; set; }
    public bool HasWorkContract { get; set; }
    public bool HasWorkPermit { get; set; }
    public bool HasUmowaOkazionalny { get; set; }
}