using NTier.Application.Clinics.Contracts;
using NTier.Application.Appointments.Dtos;

namespace NTier.Application.Clinics;

public interface IAppointmentService
{
    Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request);
    Task<List<AppointmentDto>> GetAllAsync();
    Task<AppointmentDto?> GetByPublicIdAsync(Guid apptPublicId);
}
