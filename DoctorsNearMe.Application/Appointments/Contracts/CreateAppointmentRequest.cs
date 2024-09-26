namespace DoctorsNearMe.Application.Clinics.Contracts;

public record CreateAppointmentRequest(
    Guid PatientId,
    Guid DoctorId,
    Guid ClinicId,
    DateTime StartsAt);