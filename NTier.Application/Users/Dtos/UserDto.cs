using NTier.Data.Entities;

namespace NTier.Application.Users.Dtos;

public record UserDto(int Id, Guid PublicId, string Name, string Email)
{
    public static UserDto FromEntity(User user)
    {
        return new UserDto(
            user.Id,
            user.PublicId,
            user.Name,
            user.Email);
    }
}
