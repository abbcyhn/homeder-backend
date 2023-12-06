using Application.Commons;
using Application.Commons.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCountryByName;

public class GetCountryByNameValidator : AbstractValidator<GetCountryByNameInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetCountryByNameValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _ctx = ctx;
        _localizer = localizer;

        RuleFor(t => t.CountryName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(_localizer[LocalizationMessage.COUNTRY_NAME_INVALID].Value);
    }
}