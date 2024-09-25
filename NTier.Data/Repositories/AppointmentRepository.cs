using Microsoft.EntityFrameworkCore;
using NTier.Data.Entities;
using NTier.Data.Repositories.Interfaces;

namespace NTier.Data.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    readonly AppDbContext _dbContext;

    public AppointmentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Appointment> AddAsync(Appointment appt)
    {
        var c = await _dbContext.Appointments.AddAsync(appt);
        await _dbContext.SaveChangesAsync();

        return c.Entity;
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _dbContext.Appointments
            .Include(a => a.Clinic)
            .Include(a => a.Doctor)
                .ThenInclude(d => d.User)
            .Include (a => a.Patient)
                .ThenInclude(p => p.User)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByPublicIdAsync(Guid apptPublicId)
    {
        return await _dbContext.Appointments
            .SingleOrDefaultAsync(u => u.PublicId == apptPublicId);
    }
}
