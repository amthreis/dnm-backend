using DoctorsNearMe.Application.Users.Dtos;
using DoctorsNearMe.Data.Entities;
using DoctorsNearMe.Application.Doctors.Contracts;
using DoctorsNearMe.Data.Repositories.Interfaces;

namespace DoctorsNearMe.Application.Doctors;

public class DoctorService : IDoctorService
{
    readonly IUserRepository _userRepo;
    readonly IDoctorRepository _doctorRepo;

    public DoctorService(
        IUserRepository userRepo,
        IDoctorRepository doctorRepo)
    {
        _doctorRepo = doctorRepo;
        _userRepo = userRepo;
    }

    public async Task<DoctorDto> EnrollUserAsync(EnrollUserAsDoctorRequest request)
    {
        var user = await _userRepo.GetByPublicIdAsync(request.UserId);

        if (user == null)
            throw new Exception($"User (id: {request.UserId}) not found");

        var existingPatient = await _doctorRepo.GetByUserPublicIdAsync(request.UserId);

        if (existingPatient != null)
            throw new Exception($"User (id: {request.UserId}) is already a patient");

        var newDoctor = await _doctorRepo.AddAsync(new Doctor
        {
            User = user,
            Specialties = request.Specialties,
        });

        return DoctorDto.FromEntity(newDoctor);
    }

    public async Task<List<DoctorDto>> GetAllAsync()
    {
        var all = await _doctorRepo.GetAllAsync();

        return all
            .Select(p => DoctorDto.FromEntity(p))
            .ToList();
    }
}
