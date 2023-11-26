using Application.Commons;
using Application.Commons.Resources;
using Application.Regions.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetStateByName;

public class GetStateByNameValidator : AbstractValidator<GetStateByNameInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetStateByNameValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _localizer = localizer;
        _ctx = ctx;

        RuleFor(t => t.StateName)
            .NotNull().WithMessage(_localizer[LocalizationMessage.STATE_NAME_INVALID].Value);

        RuleFor(t => t.CountryId)
            .Must(BeExists).WithMessage(_localizer[LocalizationMessage.COUNTRY_ID_INVALID].Value);
    }

    private bool BeExists(int countryId)
    {
        return _ctx.GetEntity<Country>().Any(x => x.Id == countryId);
    }
}