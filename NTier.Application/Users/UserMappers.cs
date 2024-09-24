using NTier.Application.Users.Dtos;
using NTier.Data.Entities;

namespace NTier.Application.Users;

public static class UserMappers
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto(user);
    }
}
