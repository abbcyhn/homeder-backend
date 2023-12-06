using Application.Commons.Mediator;

namespace Application.Regions.Features.GetLocationById;

public record GetLocationByIdResponse : BaseResponse
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Street { get; set; }
    public string Latitude { get; set; }
    public string Longitude  { get; set; }
}