using Application.Commons.Mediator;

namespace Application.Regions.Features.GetCountryByName;

public record GetCountryByNameRequest : BaseRequest<IdValueResponse>
{
    public string CountryName { get; set; }
}