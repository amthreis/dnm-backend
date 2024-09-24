using NTier.Application.Patients.Contracts;
using NTier.Application.Users.Dtos;

namespace NTier.Application.Patients;

public interface IPatientService
{
    Task<PatientDto> EnrollUserAsync(EnrollUserAsPatientRequest request);
    Task<List<PatientDto>> GetAllAsync();
}
