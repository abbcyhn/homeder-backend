using Application.Commons;
using Application.Commons.Resources;
using Application.Regions.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdInputValidator : AbstractValidator<GetCountryByIdInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetCountryByIdInputValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _ctx = ctx;
        _localizer = localizer;

        RuleFor(t => t.CountryId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(_localizer[LocalizationMessage.COUNTRY_NOT_EXISTS].Value)
            .Must(BeExists).WithMessage(_localizer[LocalizationMessage.COUNTRY_NOT_EXISTS].Value);
    }

    private bool BeExists(int countryId)
    {
        return _ctx.GetEntity<Country>().Any(x => x.Id == countryId);
    }
}