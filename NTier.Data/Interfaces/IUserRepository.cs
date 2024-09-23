using NTier.Data.Entities;

namespace NTier.Data.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
}
