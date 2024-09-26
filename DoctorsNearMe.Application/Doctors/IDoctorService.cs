using DoctorsNearMe.Application.Doctors.Contracts;
using DoctorsNearMe.Application.Users.Dtos;

namespace DoctorsNearMe.Application.Doctors;

public interface IDoctorService
{
    Task<DoctorDto> EnrollUserAsync(EnrollUserAsDoctorRequest request);
    Task<List<DoctorDto>> GetAllAsync();
}
