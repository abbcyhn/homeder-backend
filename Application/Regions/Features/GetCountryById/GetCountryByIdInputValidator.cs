using Application.Commons;
using Application.Regions.Configs;
using FluentValidation;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdInputValidator : AbstractValidator<GetCountryByIdInput>
{
    private readonly AppDbContext _ctx;

    public GetCountryByIdInputValidator(AppDbContext ctx)
    {
        _ctx = ctx;

        RuleFor(t => t.Id).NotEmpty().WithMessage("Id can not be null");
        RuleFor(t => t.Id).Must(BeExists).WithMessage("Country does not exist");
    }

    private bool BeExists(int id)
    {
        return _ctx.GetEntity<Country>().Any(x => x.Id == id);
    }
}