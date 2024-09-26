using DoctorsNearMe.Data.Entities;
using NetTopologySuite.Geometries;

namespace DoctorsNearMe.Data.Repositories.Interfaces;

public interface IAppointmentRepository
{
    Task<Appointment> AddAsync(Appointment appt);
    Task<List<Appointment>> GetAllAsync();
    Task<Appointment?> GetByPublicIdAsync(Guid apptPublicId);
}
