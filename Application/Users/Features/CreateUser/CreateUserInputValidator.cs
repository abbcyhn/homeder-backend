using Application.Commons.Helpers;
using Application.Users.Enums;
using Application.Users.Features.CreateUser.Services.TokenService;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.CreateUser;

public class CreateUserInputValidator : AbstractValidator<CreateUserInput>
{
    private readonly ITokenService _tokenService;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public CreateUserInputValidator(ITokenService tokenService, IStringLocalizer<LocalizationMessage> localizer)
    {
        _tokenService = tokenService;
        _localizer = localizer;

        RuleFor(t => t.GoogleToken)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(_localizer[LocalizationMessage.TOKEN_INVALID].Value)
            .NotEmpty().WithMessage(_localizer[LocalizationMessage.TOKEN_INVALID].Value)
            .Must(BeValid).WithMessage(_localizer[LocalizationMessage.TOKEN_INVALID].Value);

        RuleFor(t => t.UserRole)
            .Cascade(CascadeMode.Stop)
            .Must(BeValidUserRole).WithMessage(_localizer[LocalizationMessage.USER_ROLE_INVALID].Value);
    }

    private bool BeValid(string googleToken) 
    {
        bool isValid = _tokenService.ValidateGoogleTokenAsync(googleToken);
        return isValid;
    }
    
    private bool BeValidUserRole(UserRoleEnum userRoleEnum)
    {
        var type = userRoleEnum.GetType();
        return type.IsEnum && Enum.IsDefined(type, userRoleEnum) && userRoleEnum != UserRoleEnum.None;
    }
}
