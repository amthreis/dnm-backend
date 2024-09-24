using NTier.Data.Entities;

namespace NTier.Application.Users.Dtos;

public record UserDto(int Id, Guid PublicId, string Name, string Email)
{
    //public int Id { get; init; }
    //public Guid PublicId { get; init; }
    //public string Name { get; init; } = string.Empty;
    //public string Email { get; init; } = string.Empty;

    public UserDto(User user) 
        : this(user.Id, user.PublicId, user.Name, user.Email)
    {
        //Id = user.Id;
        //PublicId = user.PublicId;
        //Name = user.Name;
        //Email = user.Email;
    }
}
