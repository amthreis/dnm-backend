using NTier.Data.Entities;
using NTier.Data.Repositories.Interfaces;
using NTier.Application.Clinics.Dtos;
using NTier.Application.Clinics.Contracts;
using NTier.Application.Clinics.Utils;
using Azure;

namespace NTier.Application.Clinics;

public class ClinicService : IClinicService
{
    readonly IClinicRepository _clinicRepo;

    public ClinicService(
        IClinicRepository clinicRepo)
    {
        _clinicRepo = clinicRepo;
    }

    public async Task<ClinicDto> CreateAsync(CreateClinicRequest request)
    {
        var existingClinic = await _clinicRepo.GetByJuridicalPersonId(request.JuridicalPersonId);

        if (existingClinic == null)
            throw new Exception("A Clinic with this juridical person id already exists");

        var newClinic = await _clinicRepo.AddAsync(new Clinic
        {
            JuridicalPersonId = request.JuridicalPersonId,
            Location = request.LongLat.ToPoint(),
            Name = request.Name,
        });

        return ClinicDto.FromEntity(newClinic);
    }

    public async Task<List<ClinicDto>> GetAllAsync()
    {
        var all = await _clinicRepo.GetAllAsync();

        return all
            .Select(p => ClinicDto.FromEntity(p))
            .ToList();
    }

    public async Task<ClinicDto?> GetByJuridicalPersonIdAsync(string jpId)
    {
        var c = await _clinicRepo
            .GetByJuridicalPersonId(jpId);

        return ClinicDto.FromEntity(c);
    }

    public Task<ClinicDto?> GetByPublicIdAsync(Guid publicId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ClinicNearMeDto>> GetNearCoord(LongLat longLat, int pageSize, int page)
    {
        var pt = longLat.ToPoint();

        var clinics = await _clinicRepo
            .GetNearCoord(pt, pageSize, page);

        return clinics
            .Select(c => ClinicNearMeDto.FromEntity(c, pt))
            .ToList();
    }
}
