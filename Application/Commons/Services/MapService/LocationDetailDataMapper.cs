using AutoMapper;

namespace Application.Commons.Services.MapService;

public class LocationDetailDataMapper : Profile
{
    public LocationDetailDataMapper()
    {
        CreateMap<LocationDetailRoot, LocationDetailData>()
            .ForMember(dest => dest.CountryName, opt => 
                opt.MapFrom(src => GetNameByType(src, "country")))
            .ForMember(dest => dest.StateName, opt => 
                opt.MapFrom(src => GetNameByType(src, "administrative_area_level_1")))
            .ForMember(dest => dest.CityName, opt => 
                opt.MapFrom(src => GetNameByType(src, "locality")))
            .ForMember(dest => dest.DistrictName, opt => 
                opt.MapFrom(src => GetNameByType(src, "sublocality_level_1")))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => GetStreetName(src)))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => GetLatitude(src)))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => GetLongitude(src)));
    }

    private string GetNameByType(LocationDetailRoot root, string type)
    {
        var components = root?.Result?.Components;

        if (components == null)
            return string.Empty;
        
        return components.FirstOrDefault(c => 
                c.Types != null && c.Types.Contains(type)
            )?.LongName;
    }

    private string GetStreetName(LocationDetailRoot root)
    {
        return string.Concat(GetNameByType(root, "route"), " ", GetNameByType(root, "street_number"));
    }

    private decimal GetLatitude(LocationDetailRoot root)
    {
        var location = root?.Result?.Geometry?.Location;

        if (location == null)
            return 0;

        return location.Latitude;
    }

    private decimal GetLongitude(LocationDetailRoot root)
    {
        var location = root?.Result?.Geometry?.Location;

        if (location == null)
            return 0;

        return location.Longitude;
    }
}