using Application.Commons;
using Application.Regions.Entities;
using Application.Users.Entities;
using FluentValidation;

namespace Application.Users.Features.UpdateUser;

public class UpdateUserInputValidator : AbstractValidator<UpdateUserInput>
{
    private readonly AppDbContext _ctx;

    public UpdateUserInputValidator(AppDbContext ctx)
    {
        _ctx = ctx;

        RuleFor(t => t.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Given name can not be empty")
            .MaximumLength(255).WithMessage("Given name length can not be more than 255 characters");

        RuleFor(t => t.Surname)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Given surname can not be empty")
            .MaximumLength(255).WithMessage("Given surname length can not be more than 255 characters");

        RuleFor(t => t.Birthdate)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Given birthdate can not be empty")
            .Must(BeAtLeast14YearsOld).WithMessage("Given birthdate is not valid");

        RuleFor(t => t.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Given email can not be empty")
            .MaximumLength(255).WithMessage("Given email length can not be more than 255 characters")
            .EmailAddress().WithMessage("Given email is not valid");

        RuleFor(t => t.PhoneNumber)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(50).WithMessage("Given surname length can not be more than 50 characters");

        RuleFor(t => t.PhoneCountryCode)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidCountryCode).WithMessage("Given phone country code is not valid")
            .When(t => !string.IsNullOrEmpty(t.PhoneNumber));

        RuleFor(t => t.Citizenship)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidCitizenship).WithMessage("Given citizenship is not valid");

        RuleFor(t => t.NumberOfPeople)
            .Cascade(CascadeMode.Stop)
            .GreaterThanOrEqualTo(1).WithMessage("Given number of people can not be lower than 1");

        RuleFor(t => t.UserType)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidUserType).WithMessage("Given user type is not valid");

        RuleFor(t => t.UserRole)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidUserRole).WithMessage("Given user role is not valid");
    }

    private bool BeAtLeast14YearsOld(DateTime birthDate)
    {
        return (DateTime.Now.Year - birthDate.Year) >= 14;
    }

    private bool BeValidCountryCode(int phoneCountryCode)
    {
        return _ctx.GetEntity<CountryCode>().Any(x => x.Id == phoneCountryCode);
    }

    private bool BeValidCitizenship(int citizenship)
    {
        return _ctx.GetEntity<Citizenship>().Any(x => x.Id == citizenship);
    }

    private bool BeValidUserType(int userType)
    {
        return _ctx.GetEntity<UserType>().Any(x => x.Id == userType);
    }

    private bool BeValidUserRole(int userRole)
    {
        return _ctx.GetEntity<UserRole>().Any(x => x.Id == userRole);
    }
}