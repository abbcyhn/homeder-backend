namespace Application.Commons.Utilities;

public class ConverterUtility : IConverterUtility
{
    public async Task<byte[]> ConvertPhotoUrlToBytes(string photoUrl, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new ();

        try 
        {
            HttpResponseMessage response = await httpClient.GetAsync(photoUrl, cancellationToken);

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
