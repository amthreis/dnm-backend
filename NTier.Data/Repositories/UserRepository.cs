using Microsoft.EntityFrameworkCore;
using NTier.Data.Entities;

namespace NTier.Data.Repositories;

public class UserRepository : IUserRepository
{
    readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddAsync(User user)
    {
        var u = await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return u.Entity;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }
}
