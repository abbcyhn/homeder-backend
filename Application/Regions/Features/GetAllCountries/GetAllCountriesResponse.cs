namespace Application.Regions.Features.GetAllCountries;

public record GetAllCountriesResponse
{
    public List<GetAllCountriesDto> Countries { get; set; } = new List<GetAllCountriesDto>();
}

public record GetAllCountriesDto
{
    public int Id { get; set; }
    public string Value { get; set; }
}