using MediatR;

namespace Application.Regions.Features.GetCountryById;

public record GetCountryByIdRequest : IRequest<GetCountryByIdResponse>
{
    public int Id { get; set; }
}
