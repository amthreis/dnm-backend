using NTier.Data.Entities;

namespace NTier.Data.Repositories.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor> AddAsync(Doctor doctor);
    Task<List<Doctor>> GetAllAsync();
    Task<Doctor?> GetByUserPublicIdAsync(Guid userPublicId);
}
