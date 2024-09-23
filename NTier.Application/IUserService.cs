using NTier.Data.Entities;

namespace NTier.Application;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
}
