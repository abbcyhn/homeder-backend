using Application.Commons.Configs;
using Application.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Users.Configs;

public class UserTypeConfig : IdValueEntityConfig<UserType>
{
    public override void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.ToTable("USER_TYPES");
    }
}