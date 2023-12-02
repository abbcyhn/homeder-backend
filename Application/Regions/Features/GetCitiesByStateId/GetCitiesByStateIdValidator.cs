using Application.Commons;
using Application.Commons.Resources;
using Application.Regions.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCitiesByStateId;

public class GetCitiesByStateIdValidator : AbstractValidator<GetCitiesByStateIdInput>
{
    private readonly AppDbContext _ctx;
    private readonly IStringLocalizer<LocalizationMessage> _localizer;

    public GetCitiesByStateIdValidator(AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _localizer = localizer;
        _ctx = ctx;

        RuleFor(t => t.StateId)
            .Must(BeExists).WithMessage(_localizer[LocalizationMessage.STATE_ID_INVALID].Value);
    }

    private bool BeExists(int stateId)
    {
        return _ctx.GetEntity<State>().Any(x => x.Id == stateId);
    }
}