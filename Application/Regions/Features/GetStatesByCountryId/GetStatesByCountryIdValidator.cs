using Application.Commons;
using Application.Commons.Resources;
using Application.Regions.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetStatesByCountryId;

public class GetStatesByCountryIdValidator : AbstractValidator<GetStatesByCountryIdInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetStatesByCountryIdValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _localizer = localizer;
        _ctx = ctx;

        RuleFor(t => t.CountryId)
            .Must(BeExists).WithMessage(_localizer[LocalizationMessage.COUNTRY_ID_INVALID].Value);
    }

    private bool BeExists(int countryId)
    {
        return _ctx.GetEntity<Country>().Any(x => x.Id == countryId);
    }
}