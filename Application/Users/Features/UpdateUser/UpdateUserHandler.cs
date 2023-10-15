using Application.Commons;
using Application.Users.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.UpdateUser;

public class UpdateUserHandler : BaseRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    public UpdateUserHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId != request.LoggedUserId)
            throw new UnauthorizedAccessException("Given user id is not valid");

        var user = await _ctx.GetEntity<User>()
            .Include(x => x.UserDetail)
            .Include(x => x.UserEmails)
            .Include(x => x.UserPhones)
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        user.Name = request.Name;
        user.Surname = request.Surname;
        user.Birthdate = request.Birthdate;
        user.IdRole = request.IdRole;

        user.UserDetail.IdUserType = request.IdUserType;
        user.UserDetail.HasChild = request.HasChild;
        user.UserDetail.IsSmoker = request.IsSmoker;
        user.UserDetail.HasBankStatement = request.HasBankStatement;
        user.UserDetail.HasUmowaOkazionalny = request.HasUmowaOkazionalny;
        user.UserDetail.HasWorkContract = request.HasWorkContract;
        user.UserDetail.HasWorkPermit = request.HasWorkPermit;

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            user.UserPhones = new List<UserPhone>()
            {
                new ()
                {
                    IdCountryCode = request.PhoneCountryCode,
                    PhoneNumber = request.PhoneNumber,
                }
            };
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            user.UserEmails = new List<UserEmail>()
            {
                new ()
                {
                    Email = request.Email,
                }
            };
        }

        _ctx.GetEntity<User>().Update(user);

        await _ctx.SaveChangesAsync(cancellationToken);

        return new UpdateUserResponse();
    }
}