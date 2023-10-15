using Application.Users.Features.CreateUser.Services.TokenService;
using FluentValidation;

namespace Application.Users.Features.CreateUser;

public class CreateUserInputValidator : AbstractValidator<CreateUserInput>
{
    private readonly ITokenService _tokenService;

    public CreateUserInputValidator(ITokenService tokenService)
    {
        _tokenService = tokenService;
        RuleFor(t => t.GoogleToken)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Given token can not be null")
            .NotEmpty().WithMessage("Given token can not be empty")
            .Must(BeValid).WithMessage("Given token is not valid");
    }

    private bool BeValid(string googleToken) 
    {
        bool isValid = _tokenService.ValidateGoogleTokenAsync(googleToken);
        return isValid;
    }
}
