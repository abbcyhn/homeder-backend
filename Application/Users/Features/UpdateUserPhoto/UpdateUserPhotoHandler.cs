using MediatR;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoHandler : IRequestHandler<UpdateUserPhotoRequest, UpdateUserPhotoResponse>
{
    public async Task<UpdateUserPhotoResponse> Handle(UpdateUserPhotoRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId != request.LoggedUserId) 
            throw new UnauthorizedAccessException("Given user id is not valid");

        string photoPath = GetPhotoPath(request.UserId);
        await File.WriteAllBytesAsync(photoPath, request.UserPhoto, cancellationToken);

        return new UpdateUserPhotoResponse { PhotoUrl = $"{request.HostUrl}/users/{request.UserId}/photo" };
    }

    private string GetPhotoPath(int userId)
    {
        string folderPath = "Photos";
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        return $"{folderPath}/user-{userId}.png";
    }
}