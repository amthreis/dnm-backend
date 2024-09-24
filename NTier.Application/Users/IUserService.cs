using NTier.Application.Users.Contracts;
using NTier.Application.Users.Dtos;

namespace NTier.Application.Users;

public interface IUserService
{
    Task<UserDto> AddAsync(CreateUserRequest request);
    Task<List<UserDto>> GetAllAsync();
    //Task<UserDto?> GetByPublicIdAsync(Guid userId);
}
