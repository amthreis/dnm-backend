using NTier.Data.Entities;

namespace NTier.Data.Repositories.Interfaces;

public interface IPatientRepository
{
    Task<Patient> AddAsync(Patient patient);
    Task<List<Patient>> GetAllAsync();
    Task<Patient?> GetByUserPublicIdAsync(Guid userPublicId);
}
