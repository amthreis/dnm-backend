using NTier.Data.Entities;

namespace NTier.Application.Services;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
}
