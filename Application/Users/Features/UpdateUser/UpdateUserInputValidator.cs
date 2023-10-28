using Application.Commons;
using Application.Commons.Resources;
using Application.Regions.Entities;
using Application.Users.Enums;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.UpdateUser;

public class UpdateUserInputValidator : AbstractValidator<UpdateUserInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public UpdateUserInputValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _ctx = ctx;
        _localizer = localizer;

        RuleFor(t => t.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(_localizer[LocalizationMessage.USER_NAME_INVALID].Value)
            .MaximumLength(255).WithMessage(_localizer[LocalizationMessage.USER_NAME_MAXLEN_EXCEED].Value);

        RuleFor(t => t.Surname)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(_localizer[LocalizationMessage.USER_SURNAME_INVALID].Value)
            .MaximumLength(255).WithMessage(_localizer[LocalizationMessage.USER_SURNAME_MAXLEN_EXCEED].Value);

        RuleFor(t => t.Birthdate)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(_localizer[LocalizationMessage.USER_BIRTHDATE_INVALID].Value)
            .Must(BeAtLeast14YearsOld).WithMessage(_localizer[LocalizationMessage.USER_BIRTHDATE_INVALID].Value);

        RuleFor(t => t.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(_localizer[LocalizationMessage.USER_EMAIL_INVALID].Value)
            .EmailAddress().WithMessage(_localizer[LocalizationMessage.USER_EMAIL_INVALID].Value)
            .MaximumLength(255).WithMessage(_localizer[LocalizationMessage.USER_EMAIL_MAXLEN_EXCEED].Value);

        RuleFor(t => t.PhoneNumber)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(50).WithMessage(_localizer[LocalizationMessage.USER_PHONE_MAXLEN_EXCEED].Value);

        RuleFor(t => t.PhoneCountryCode)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidCountryCode).WithMessage(_localizer[LocalizationMessage.USER_PHONE_CODE_INVALID].Value)
            .When(t => !string.IsNullOrEmpty(t.PhoneNumber));

        RuleFor(t => t.Citizenship)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidCitizenship).WithMessage(_localizer[LocalizationMessage.USER_CITIZENSHIP_INVALID].Value);

        RuleFor(t => t.NumberOfPeople)
            .Cascade(CascadeMode.Stop)
            .GreaterThanOrEqualTo(1).WithMessage(_localizer[LocalizationMessage.NO_OF_PEOPLE_INVALID].Value);

        RuleFor(t => t.UserType)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidUserType).WithMessage(_localizer[LocalizationMessage.USER_TYPE_INVALID].Value);

        RuleFor(t => t.UserRole)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidUserRole).WithMessage(_localizer[LocalizationMessage.USER_ROLE_INVALID].Value);
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

    private bool BeValidUserType(UserTypeEnum userTypeEnum)
    {
        var type = userTypeEnum.GetType();
        return type.IsEnum && Enum.IsDefined(type, userTypeEnum) && userTypeEnum != UserTypeEnum.None;
    }

    private bool BeValidUserRole(UserRoleEnum userRoleEnum)
    {
        var type = userRoleEnum.GetType();
        return type.IsEnum && Enum.IsDefined(type, userRoleEnum) && userRoleEnum != UserRoleEnum.None;
    }
}