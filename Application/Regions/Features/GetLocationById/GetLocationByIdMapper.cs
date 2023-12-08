using Application.Commons.Mediator;
//using Application.Commons.Services.MapService;
using AutoMapper;

namespace Application.Regions.Features.GetLocationById;

public class GetLocationByIdMapper : Profile
{
    public GetLocationByIdMapper()
    {
        CreateMap<GetLocationByIdInput, GetLocationByIdRequest>();

        CreateMap<Tuple<IdValueResponse, IdValueResponse, IdValueResponse, IdValueResponse, LocationDetailData>, GetLocationByIdResponse>()
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Item1.Data.Id))
            .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.Item2.Data.Id))
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Item3.Data.Id))
            .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.Item4.Data.Id))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Item5.Street))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Item5.Latitude))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Item5.Longitude));
    }
}