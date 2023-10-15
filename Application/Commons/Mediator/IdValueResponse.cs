namespace Application.Commons.Mediator;

public record IdValueResponse : BaseResponse
{
    public IdValueDto Data { get; set; } = new IdValueDto();
}