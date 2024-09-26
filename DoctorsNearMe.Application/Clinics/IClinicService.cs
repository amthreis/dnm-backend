using DoctorsNearMe.Application.Clinics.Contracts;
using DoctorsNearMe.Application.Clinics.Dtos;
using DoctorsNearMe.Application.Clinics.Utils;

namespace DoctorsNearMe.Application.Clinics;

public interface IClinicService
{
    Task<ClinicDto> CreateAsync(CreateClinicRequest request);
    Task<List<ClinicDto>> GetAllAsync();
    Task<ClinicDto?> GetByPublicIdAsync(Guid publicId);
    Task<ClinicDto?> GetByJuridicalPersonIdAsync(string jpId);
    Task<List<ClinicNearMeDto>> GetNearCoord(LongLat longLat, int pageSize, int page);
}
