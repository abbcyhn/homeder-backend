using MediatR;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoHandler : IRequestHandler<UpdateUserPhotoRequest, UpdateUserPhotoResponse>
{
    public async Task<UpdateUserPhotoResponse> Handle(UpdateUserPhotoRequest request, CancellationToken cancellationToken)
    {
        string photoPath = GetPhotoPath(request.UserId);
        await File.WriteAllBytesAsync(photoPath, request.UserPhoto, cancellationToken);
        var response = new UpdateUserPhotoResponse { PhotoUrl = $"{request.HostUrl}/users/{request.UserId}/photo" };
        return response;
    }

    private string GetPhotoPath(int userId)
    {
        string folderPath = "Photos";
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        return $"{folderPath}/user-{userId}.png";
    }
}
