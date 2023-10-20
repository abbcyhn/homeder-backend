using Application.Commons;
using Application.Commons.Mediator;
using Application.Users.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.UpdateUser;

public class UpdateUserHandler : BaseHandler<UpdateUserRequest, UpdateUserResponse>
{
    public UpdateUserHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<UpdateUserResponse> Execute(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _ctx.GetEntity<User>()
            .Include(x => x.UserDetail)
            .Include(x => x.UserEmails)
            .Include(x => x.UserPhones)
            .FirstAsync(x => x.Id == request.UserId, cancellationToken);

        user.Name = request.Name;
        user.Surname = request.Surname;
        user.Birthdate = request.Birthdate;
        user.IdRole = request.IdRole;

        user.UserDetail = new UserDetail
        {
            IdUserType = request.IdUserType,
            HasChild = request.HasChild,
            IsSmoker = request.IsSmoker,
            HasBankStatement = request.HasBankStatement,
            HasUmowaOkazionalny = request.HasUmowaOkazionalny,
            HasWorkContract = request.HasWorkContract,
            HasWorkPermit = request.HasWorkPermit
        };

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