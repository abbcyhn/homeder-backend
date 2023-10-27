using Application.Commons.DataAccess;
using Application.Commons.Helpers;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCountries;

public class GetAllCountriesHandler : BaseHandler<GetCountriesRequest, IdValueListResponse>
{
    public GetAllCountriesHandler(IMapper mapper, IUnitOfWork uow, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, uow, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await _uow.Repository<Country>().ListAllAsync();
        return _mapper.Map<IdValueListResponse>(countries);
    }
}
