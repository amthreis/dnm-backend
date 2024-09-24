using NTier.Data.Entities;

namespace NTier.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByPublicIdAsync(Guid userId);
}
