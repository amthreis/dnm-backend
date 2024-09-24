using NTier.Application.Clinics.Contracts;
using NTier.Application.Clinics.Dtos;
using NTier.Application.Clinics.Utils;

namespace NTier.Application.Clinics;

public interface IClinicService
{
    Task<ClinicDto> CreateAsync(CreateClinicRequest request);
    Task<List<ClinicDto>> GetAllAsync();
    Task<ClinicDto?> GetByPublicIdAsync(Guid publicId);
    Task<ClinicDto?> GetByJuridicalPersonIdAsync(string jpId);
    Task<List<ClinicNearMeDto>> GetNearCoord(LongLat longLat, int pageSize, int page);
}
