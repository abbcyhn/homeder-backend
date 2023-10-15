namespace Application.Users.Features.CreateUser.Services.ImageService;

public interface IImageService
{
    Task<byte[]> ConvertImageUrlToBytes(string imageUrl, CancellationToken cancellationToken);
}
