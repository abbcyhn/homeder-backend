using AutoMapper;

namespace Application.Regions.Features.GetCitiesByStateId;

public class GetCitiesByStateIdMapper : Profile
{
    public GetCitiesByStateIdMapper()
    {
        CreateMap<GetCitiesByStateIdInput, GetCitiesByStateIdRequest>();
    }
}