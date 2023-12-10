using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Commons.Services.MapService;
using Application.Regions.Features.GetCityByName;
using Application.Regions.Features.GetCountryByName;
using Application.Regions.Features.GetDistrictByName;
using Application.Regions.Features.GetStateByName;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetLocationById;

public class GetLocationByIdHandler(IMapper mapper,
        AppDbContext ctx,
        IMediator mediator,
        IMapService mapService,
        IStringLocalizer<LocalizationMessage> localizer)
    : BaseHandler<GetLocationByIdRequest, GetLocationByIdResponse>(mapper, ctx, localizer)
{
    public override async Task<GetLocationByIdResponse> Execute(GetLocationByIdRequest request, 
        CancellationToken cancellationToken)
    {
        var location = await mapService.GetLocation(request.LocationId, cancellationToken);

        var country = await mediator.Send(GetCountryRequest(location), cancellationToken);
        var state = await mediator.Send(GetStateRequest(location, country), cancellationToken);
        var city = await mediator.Send(GetCityRequest(location, state), cancellationToken);
        var district = await mediator.Send(GetDistrictRequest(location, city), cancellationToken);

        var tuple = Tuple.Create(country, state, city, district, location);
        return _mapper.Map<GetLocationByIdResponse>(tuple);
    }

    private int GetId(IdValueResponse response)
    {
        if (response == null || response.Data == null)
            return 0;
        
        return response.Data.Id;
    }

    private GetCountryByNameRequest GetCountryRequest(LocationDetailData location)
    {
        return new GetCountryByNameRequest { CountryName = location.CountryName };
    }

    private GetStateByNameRequest GetStateRequest(LocationDetailData location, IdValueResponse response)
    {
        return new GetStateByNameRequest { CountryId = GetId(response), StateName = location.StateName };
    }

    private GetCityByNameRequest GetCityRequest(LocationDetailData location, IdValueResponse response)
    {
        return new GetCityByNameRequest { StateId = GetId(response), CityName = location.CityName };
    }

    private GetDistrictByNameRequest GetDistrictRequest(LocationDetailData location, IdValueResponse response)
    {
        return new GetDistrictByNameRequest { CityId = GetId(response), DistrictName = location.DistrictName };
    }
}