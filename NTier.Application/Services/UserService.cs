using NTier.Data.Entities;
using NTier.Data.Repositories;

namespace NTier.Application.Services;

public class UserService : IUserService
{
    readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public Task<User> AddAsync(User user)
    {
        return _userRepo.AddAsync(user);
    }

    public Task<List<User>> GetAllAsync()
    {
        return _userRepo.GetAllAsync();
    }
}
