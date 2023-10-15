using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Users.Features.GetCitizenships;

public class GetCitizenshipsMapper : Profile
{
    public GetCitizenshipsMapper()
    {
        CreateMap<GetCitizenshipsInput, GetCitizenshipsRequest>();
 
        CreateMap<Citizenship, IdValueDto>();

        CreateMap<List<Citizenship>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}