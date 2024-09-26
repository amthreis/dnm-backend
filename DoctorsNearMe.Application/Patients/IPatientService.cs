using DoctorsNearMe.Application.Patients.Contracts;
using DoctorsNearMe.Application.Users.Dtos;

namespace DoctorsNearMe.Application.Patients;

public interface IPatientService
{
    Task<PatientDto> EnrollUserAsync(EnrollUserAsPatientRequest request);
    Task<List<PatientDto>> GetAllAsync();
}
