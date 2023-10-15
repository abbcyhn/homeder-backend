using Application.Commons;
using Application.Regions.Entities;
using FluentValidation;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdInputValidator : AbstractValidator<GetCountryByIdInput>
{
    private readonly AppDbContext _ctx;

    public GetCountryByIdInputValidator(AppDbContext ctx)
    {
        _ctx = ctx;

        RuleFor(t => t.CountryId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Id can not be null")
            .Must(BeExists).WithMessage("Country does not exist");
    }

    private bool BeExists(int countryId)
    {
        return _ctx.GetEntity<Country>().Any(x => x.Id == countryId);
    }
}