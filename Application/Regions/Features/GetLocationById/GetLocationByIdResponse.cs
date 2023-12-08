using Application.Commons.Mediator;

namespace Application.Regions.Features.GetLocationById;

public record GetLocationByIdResponse : BaseResponse
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Street { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude  { get; set; }
}