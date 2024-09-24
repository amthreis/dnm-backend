using Azure;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NTier.Data.Entities;
using NTier.Data.Repositories.Interfaces;
using System.Numerics;

namespace NTier.Data.Repositories;

public class ClinicRepository : IClinicRepository
{
    readonly AppDbContext _dbContext;

    public ClinicRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Clinic> AddAsync(Clinic clinic)
    {
        var c = await _dbContext.Clinics.AddAsync(clinic);
        await _dbContext.SaveChangesAsync();

        return c.Entity;
    }

    public async Task<List<Clinic>> GetAllAsync()
    {
        return await _dbContext.Clinics.ToListAsync();
    }

    public async Task<Clinic?> GetByJuridicalPersonId(string jpId)
    {
        return await _dbContext.Clinics
            .SingleOrDefaultAsync(u => u.JuridicalPersonId == jpId);
    }

    public async Task<Clinic?> GetByPublicIdAsync(Guid clinicPublicId)
    {
        return await _dbContext.Clinics
            .SingleOrDefaultAsync(u => u.PublicId == clinicPublicId);
    }

    public async Task<List<Clinic>> GetNearCoord(Point pt, int pageSize, int page)
    {
        var clinics = await _dbContext.Clinics
            .AsNoTracking()
            .OrderBy(c => c.Location.Distance(pt))
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .ToListAsync();

        return clinics;
    }
}
