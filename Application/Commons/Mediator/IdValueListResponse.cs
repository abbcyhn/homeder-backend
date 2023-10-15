namespace Application.Commons.Mediator;

public record IdValueListResponse : BaseResponse
{
    public List<IdValueDto> Data { get; set; } = new List<IdValueDto>();
}
