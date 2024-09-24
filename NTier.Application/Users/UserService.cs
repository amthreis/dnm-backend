using NTier.Application.Users.Contracts;
using NTier.Application.Users.Dtos;
using NTier.Data.Entities;
using NTier.Data.Repositories;

namespace NTier.Application.Users;

public class UserService : IUserService
{
    readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<UserDto> AddAsync(CreateUserRequest request)
    {
        var user = await _userRepo.AddAsync(new User
        {
            Email = request.Email,
            Name = request.Name,
            PublicId = Guid.NewGuid(),
        });

        return new UserDto(user);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var all = await _userRepo.GetAllAsync();

        return all
            .Select(u => new UserDto(u))
            .ToList();
    }
}
