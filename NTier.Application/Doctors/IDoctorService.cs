using NTier.Application.Doctors.Contracts;
using NTier.Application.Users.Dtos;

namespace NTier.Application.Doctors;

public interface IDoctorService
{
    Task<DoctorDto> EnrollUserAsync(EnrollUserAsDoctorRequest request);
    Task<List<DoctorDto>> GetAllAsync();
}
