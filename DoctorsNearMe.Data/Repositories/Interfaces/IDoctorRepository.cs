using DoctorsNearMe.Data.Entities;

namespace DoctorsNearMe.Data.Repositories.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor> AddAsync(Doctor doctor);
    Task<List<Doctor>> GetAllAsync();
    Task<Doctor?> GetByUserPublicIdAsync(Guid userPublicId);
}
