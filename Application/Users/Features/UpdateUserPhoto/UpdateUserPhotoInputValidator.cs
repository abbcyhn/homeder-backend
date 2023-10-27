using Application.Commons.Helpers;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoInputValidator : AbstractValidator<UpdateUserPhotoInput>
{
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public UpdateUserPhotoInputValidator(IStringLocalizer<LocalizationMessage> localizer)
    {
        _localizer = localizer;

        RuleFor(x => x.UserPhoto)
            .Cascade(CascadeMode.Stop)
            .Must(BeValid).WithMessage(_localizer[LocalizationMessage.USER_PHOTO_INVALID].Value);
    }

    private bool BeValid(byte[] userPhoto)
    {
        try
        {
            using Image image = Image.Load(userPhoto); ;
            return true;
        }
        catch
        {
            return false;
        }
    }
}