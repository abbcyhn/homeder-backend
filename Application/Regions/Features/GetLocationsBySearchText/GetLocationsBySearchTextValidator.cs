using Application.Commons.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetLocationsBySearchText;

public class GetLocationsBySearchTextValidator : AbstractValidator<GetLocationsBySearchTextInput>
{
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetLocationsBySearchTextValidator(IStringLocalizer<LocalizationMessage> localizer) 
    {
        _localizer = localizer;

        RuleFor(t => t.SearchText)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(_localizer[LocalizationMessage.SEARCH_TEXT_INVALID].Value)
            .OverridePropertyName("q");
    }
}
