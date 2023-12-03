using Application.Commons;
using Application.Commons.Resources;
using Application.Regions.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetDistrictByName;

public class GetDistrictByNameValidator : AbstractValidator<GetDistrictByNameInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetDistrictByNameValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _localizer = localizer;
        _ctx = ctx;

        RuleFor(t => t.CityId)
            .Must(BeExists).WithMessage(_localizer[LocalizationMessage.CITY_ID_INVALID].Value);
    }

    private bool BeExists(int cityId)
    {
        return _ctx.GetEntity<City>().Any(x => x.Id == cityId);
    }
}