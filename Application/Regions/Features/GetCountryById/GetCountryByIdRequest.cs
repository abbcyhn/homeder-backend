using Application.Commons.Mediator;

namespace Application.Regions.Features.GetCountryById;

public record GetCountryByIdRequest : BaseRequest<IdValueResponse>
{
    public int CountryId { get; set; }
}
