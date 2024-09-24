using Microsoft.EntityFrameworkCore;
using NTier.Data.Entities;
using NTier.Data.Repositories.Interfaces;

namespace NTier.Data.Repositories;

public class DoctorRepository : IDoctorRepository
{
    readonly AppDbContext _dbContext;

    public DoctorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Doctor> AddAsync(Doctor doctor)
    {
        var u = await _dbContext.Doctors.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();

        return u.Entity;
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctors
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<Doctor?> GetByUserPublicIdAsync(Guid userPublicId)
    {
        return await _dbContext.Doctors
            .Include(p => p.User)
            .SingleOrDefaultAsync(u => u.User.PublicId == userPublicId);
    }
}
