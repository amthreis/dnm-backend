using DoctorsNearMe.Application.Users.Contracts;
using DoctorsNearMe.Application.Users.Dtos;
using DoctorsNearMe.Data.Entities;
using DoctorsNearMe.Data.Repositories.Interfaces;

namespace DoctorsNearMe.Application.Users;

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

        return UserDto.FromEntity(user);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var all = await _userRepo.GetAllAsync();

        return all
            .Select(u => UserDto.FromEntity(u))
            .ToList();
    }
}
