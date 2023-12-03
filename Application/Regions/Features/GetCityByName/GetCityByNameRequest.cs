using Application.Commons.Mediator;

namespace Application.Regions.Features.GetCityByName;

public record GetCityByNameRequest : BaseRequest<IdValueResponse>
{
    public int StateId { get; set; }
    public string CityName { get; set; }
};