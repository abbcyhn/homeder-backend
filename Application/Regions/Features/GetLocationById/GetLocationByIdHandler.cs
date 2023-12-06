using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Features.GetCityByName;
using Application.Regions.Features.GetCountryByName;
using Application.Regions.Features.GetDistrictByName;
using Application.Regions.Features.GetStateByName;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetLocationById;

public class GetLocationByIdHandler : BaseHandler<GetLocationByIdRequest, GetLocationByIdResponse>
{
    // private readonly IMapService _mapService;
    private readonly IMediator _mediator;

    public GetLocationByIdHandler(IMapper mapper, 
        AppDbContext ctx,
        IMediator mediator,
        // IMapService mapService,
        IStringLocalizer<LocalizationMessage> localizer)
        : base(mapper, ctx, localizer) 
        {
            _mediator = mediator;
            // _mapService = mapService;
        }

    public override async Task<GetLocationByIdResponse> Execute(GetLocationByIdRequest request, 
        CancellationToken cancellationToken)
    {
        var locationDetailData = new LocationDetailData();
        
        var country = await _mediator.Send(new GetCountryByNameRequest { CountryName = locationDetailData.CountyName }, cancellationToken);
        var state = await _mediator.Send(new GetStateByNameRequest { StateName = locationDetailData.StateName }, cancellationToken);
        var city = await _mediator.Send(new GetCityByNameRequest { CityName = locationDetailData.CityName }, cancellationToken);
        var district = await _mediator.Send(new GetDistrictByNameRequest { DistrictName = locationDetailData.DistrictName }, cancellationToken);

        return _mapper.Map<GetLocationByIdResponse>((country, state, city, district, locationDetailData));
    }
}