namespace Application.Regions.Features.GetCountryById;

public record GetCountryByIdResponse
{
    public int Id { get; set; }
    public string Value { get; set; }
}