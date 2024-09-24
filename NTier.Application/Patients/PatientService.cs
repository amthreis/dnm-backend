using NTier.Application.Patients.Contracts;
using NTier.Application.Users.Dtos;
using NTier.Data.Entities;
using NTier.Data.Repositories.Interfaces;

namespace NTier.Application.Patients;

public class PatientService : IPatientService
{
    readonly IUserRepository _userRepo;
    readonly IPatientRepository _patientRepo;

    public PatientService(
        IUserRepository userRepo,
        IPatientRepository patientRepo)
    {
        _patientRepo = patientRepo;
        _userRepo = userRepo;
    }

    public async Task<PatientDto> EnrollUserAsync(EnrollUserAsPatientRequest request)
    {
        var user = await _userRepo.GetByPublicIdAsync(request.UserId);

        if (user == null) 
            throw new Exception($"User (id: {request.UserId}) not found");

        var existingPatient = await _patientRepo.GetByUserPublicIdAsync(request.UserId);

        if (existingPatient != null)
            throw new Exception($"User (id: {request.UserId}) is already a patient");

        var newPatient = await _patientRepo.AddAsync(new Patient
        {
            User = user,
        });

        return PatientDto.FromEntity(newPatient);
    }

    public async Task<List<PatientDto>> GetAllAsync()
    {
        var all = await _patientRepo.GetAllAsync();

        return all
            .Select(p => PatientDto.FromEntity(p))
            .ToList();
    }
}
