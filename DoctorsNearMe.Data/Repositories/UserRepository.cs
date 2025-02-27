﻿using Microsoft.EntityFrameworkCore;
using DoctorsNearMe.Data.Entities;
using DoctorsNearMe.Data.Repositories.Interfaces;

namespace DoctorsNearMe.Data.Repositories;

public class UserRepository : IUserRepository
{
    readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddAsync(User user)
    {
        var u = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return u.Entity;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByPublicIdAsync(Guid userId)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.PublicId == userId);
    }
}
