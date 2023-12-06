using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetLocationById;

public class GetLocationByIdMapper : Profile
{
    public GetLocationByIdMapper()
    {
        CreateMap<GetLocationByIdInput, GetLocationByIdRequest>();

        CreateMap<(Country, State, City, District, LocationDetailData), GetLocationByIdResponse>()
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.Item2.Id))
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Item3.Id))
            .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.Item4.Id))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => string.Concat(src.Item5.StreetRoute, " ", src.Item5.StreetNumber)))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Item5.Latitude))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Item5.Longitude));
    }
}