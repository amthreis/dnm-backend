using DoctorsNearMe.Application.Clinics.Contracts;
using DoctorsNearMe.Application.Appointments.Dtos;

namespace DoctorsNearMe.Application.Clinics;

public interface IAppointmentService
{
    Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request);
    Task<List<AppointmentDto>> GetAllAsync();
    Task<AppointmentDto?> GetByPublicIdAsync(Guid apptPublicId);
}
