using NTier.Data.Entities;

namespace NTier.Data.Repositories;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
}
