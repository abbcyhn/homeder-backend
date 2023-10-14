using Application.Commons.Dtos;
using MediatR;

namespace Application.Regions.Features.GetCountryById;

public record GetCountryByIdRequest : IRequest<GetLibResponse>
{
    public int Id { get; set; }
}
