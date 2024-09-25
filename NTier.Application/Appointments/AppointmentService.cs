using NTier.Application.Clinics.Contracts;
using NTier.Application.Appointments.Dtos;
using NTier.Data.Repositories.Interfaces;
using NTier.Application.Clinics.Dtos;
using NTier.Data.Entities;

namespace NTier.Application.Clinics;

public class AppointmentService : IAppointmentService
{
    readonly IAppointmentRepository _appointmentRepo;
    readonly IClinicRepository _clinicRepo;
    readonly IPatientRepository _patientRepo;
    readonly IDoctorRepository _doctorRepo;

    public AppointmentService(
        IAppointmentRepository appointmentRepo,
        IClinicRepository clinicRepo,
        IPatientRepository patientRepo,
        IDoctorRepository doctorRepo)
    {
        _appointmentRepo = appointmentRepo;
        _clinicRepo = clinicRepo;
        _patientRepo = patientRepo;
        _doctorRepo = doctorRepo;
    }

    public async Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request)
    {
        var clinic = await _clinicRepo.GetByUserPublicIdAsync(request.ClinicId);

        if (clinic == null)
            throw new Exception($"Clinic (id: {request.ClinicId}) doesn't exist");

        var patient = await _patientRepo.GetByUserPublicIdAsync(request.PatientId);

        if (patient == null)
            throw new Exception($"Patient (id: {request.PatientId}) doesn't exist");

        var doctor = await _doctorRepo.GetByUserPublicIdAsync(request.DoctorId);

        if (doctor == null)
            throw new Exception($"Doctor (id: {request.DoctorId}) doesn't exist");

        var appointment = await _appointmentRepo.AddAsync(new Appointment
        {
            StartsAt = request.StartsAt,
            Clinic = clinic,
            Patient = patient,
            Doctor = doctor,
            State = AppointmentState.BeforeConfirmation,
        });

        return AppointmentDto.FromEntity(appointment);
    }

    public async Task<List<AppointmentDto>> GetAllAsync()
    {
        var all = await _appointmentRepo
            .GetAllAsync();

        return all
            .Select(AppointmentDto.FromEntity)
            .ToList();
    }

    public async Task<AppointmentDto?> GetByPublicIdAsync(Guid apptPublicId)
    {
        var appt = await _appointmentRepo.GetByPublicIdAsync(apptPublicId);

        if (appt == null)
            throw new Exception($"Appointment (id: {apptPublicId}) doesn't exist");

        return AppointmentDto.FromEntity(appt);
    }
}
