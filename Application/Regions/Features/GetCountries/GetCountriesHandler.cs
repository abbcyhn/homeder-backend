using Application.Commons;
using Application.Commons.DataAccess;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetCountries;

public class GetAllCountriesHandler : BaseHandler<GetCountriesRequest, IdValueListResponse>
{
    public GetAllCountriesHandler(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await _uow.Repository<Country>().ListAllAsync();
        return _mapper.Map<IdValueListResponse>(countries);
    }
}
