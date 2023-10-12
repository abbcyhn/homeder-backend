using Application.Commons;
using Application.Regions.Entities;
using Application.Users.Entities;
using FluentValidation;

namespace Application.Users.Features.UpdateUser;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserInput>
{
    private readonly AppDbContext _ctx;
    
    public UpdateUserRequestValidator(AppDbContext ctx)
    {
        _ctx = ctx;
        
        RuleFor(t => t.Name)
            .NotEmpty()
            .WithMessage("Given name can not be empty")
            .MaximumLength(255)
            .WithMessage("Given name length can not be more than 255 characters");

        RuleFor(t => t.Surname)
            .NotEmpty()
            .WithMessage("Given surname can not be empty")
            .MaximumLength(255)
            .WithMessage("Given surname length can not be more than 255 characters");

        RuleFor(t => t.Birthdate)
            .NotNull()
            .WithMessage("Given birthdate can not be empty")
            .Must(BeAtLeast14YearsOld)
            .WithMessage("Given birthdate is not valid");

        RuleFor(t => t.Email)
            .NotEmpty()
            .WithMessage("Given email can not be empty")
            .MaximumLength(255)
            .WithMessage("Given email length can not be more than 255 characters")
            .EmailAddress()
            .WithMessage("Given email is not valid");

        RuleFor(t => t.PhoneNumber)
            .MaximumLength(50)
            .WithMessage("Given surname length can not be more than 50 characters");

        RuleFor(t => t.PhoneCountryCode)
            .Must(BeValidCountryCode)
            .WithMessage("Given phone country code is not valid")
            .When(t => !string.IsNullOrEmpty(t.PhoneNumber));

        RuleFor(t => t.Citizenship)
            .Must(BeValidCitizenship)
            .WithMessage("Given citizenship is not valid");

        RuleFor(t => t.NumberOfPeople)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Given number of people can not be lower than 1");

        RuleFor(t => t.UserType)
            .Must(BeValidUserType)
            .WithMessage("Given user type is not valid");

        RuleFor(t => t.UserRole)
            .Must(BeValidUserRole)
            .WithMessage("Given user role is not valid");
        
        RuleFor(x => x).Custom((input, context) =>
        {
            // TODO: use enum instead of number
            if (input.NumberOfPeople > 1 && input.UserType == 1)
            {
                context.AddFailure("Given number of people and user type combination is not valid.");
            }
        });
    }
    
    private bool BeAtLeast14YearsOld(DateTime birthDate)
    {
        var age = DateTime.Now.Year - birthDate.Year;
        if (birthDate.AddYears(age) > DateTime.Now)
        {
            age--;
        }

        return age >= 14;
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