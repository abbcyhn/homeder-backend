using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetAllCitizenships;

public class GetAllCitizenshipsMapper : Profile
{
    public GetAllCitizenshipsMapper()
    {
        CreateMap<Citizenship, GetLibDto>();
        CreateMap<List<Citizenship>, GetAllLibResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}