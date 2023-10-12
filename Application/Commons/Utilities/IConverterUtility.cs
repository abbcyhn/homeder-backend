namespace Application.Commons.Utilities;

public interface IConverterUtility
{
    Task<byte[]> ConvertPhotoUrlToBytes(string photoUrl, CancellationToken cancellationToken);
}
