using Application.Regions.Entities;
using Application.Users.Entities;
using AutoMapper;

namespace Application.Commons.Mediator;

public class IdValueMapper : Profile
{
    public IdValueMapper()
    {
        IdValueDtoMapper();

        IdValueListResponseMapper();

        IdValueResponseMapper();
    }

    private void IdValueDtoMapper()
    {
        CreateMap<Country, IdValueDto>();
        
        CreateMap<State, IdValueDto>();
        
        CreateMap<City, IdValueDto>();
        
        CreateMap<District, IdValueDto>();

        CreateMap<Citizenship, IdValueDto>();
        
        CreateMap<UserType, IdValueDto>();
        
        CreateMap<CountryCode, IdValueDto>();
    }

    private void IdValueListResponseMapper()
    {
        CreateMap<List<Country>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<List<State>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<List<City>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<List<District>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<List<Citizenship>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<List<UserType>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
        
        CreateMap<List<CountryCode>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }

    private void IdValueResponseMapper()
    {
        CreateMap<Country, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<State, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<City, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<District, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<Citizenship, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        CreateMap<UserType, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}