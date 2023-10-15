namespace Application.Users.Features.CreateUser.Services.ImageService;

public class ImageService : IImageService
{
    public async Task<byte[]> ConvertImageUrlToBytes(string imageUrl, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(imageUrl, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsByteArrayAsync(cancellationToken);

            throw new Exception($"Failed to download the image. Status code: {response.StatusCode}");
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to download the image. Exception: {e.Message}");
        }
    }
}
