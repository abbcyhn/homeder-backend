using MediatR;

namespace Application.Regions.Features.GetAllCountries;

public record GetAllCountriesRequest : IRequest<GetAllCountriesResponse>
{
}
