﻿using Microsoft.EntityFrameworkCore;
using NTier.Data.Entities;
using NTier.Data.Repositories.Interfaces;

namespace NTier.Data.Repositories;

public class PatientRepository : IPatientRepository
{
    readonly AppDbContext _dbContext;

    public PatientRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Patient> AddAsync(Patient patient)
    {
        var u = await _dbContext.Patients.AddAsync(patient);
        await _dbContext.SaveChangesAsync();

        return u.Entity;
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        var patients = await _dbContext.Patients
            .Include(p => p.User)
            .ToListAsync();

        return patients;
    }

    public async Task<Patient?> GetByUserPublicIdAsync(Guid userPublicId)
    {
        return await _dbContext.Patients
            .Include(p => p.User)
            .SingleOrDefaultAsync(u => u.User.PublicId == userPublicId);
    }
}
