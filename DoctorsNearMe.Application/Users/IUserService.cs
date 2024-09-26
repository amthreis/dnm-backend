using DoctorsNearMe.Application.Users.Contracts;
using DoctorsNearMe.Application.Users.Dtos;

namespace DoctorsNearMe.Application.Users;

public interface IUserService
{
    Task<UserDto> AddAsync(CreateUserRequest request);
    Task<List<UserDto>> GetAllAsync();
    //Task<UserDto?> GetByPublicIdAsync(Guid userId);
}
