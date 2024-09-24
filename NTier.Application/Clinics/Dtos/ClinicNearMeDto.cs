using NetTopologySuite.Geometries;
using NTier.Data.Entities;

namespace NTier.Application.Clinics.Dtos;

public record ClinicNearMeDto(
    int Id,
    Guid PublicId,
    string Name,
    double Distance)
{

    public static ClinicNearMeDto FromEntity(Clinic clinic, Point from)
    {
        return new ClinicNearMeDto(
            clinic.Id,
            clinic.PublicId,
            clinic.Name,
            clinic.GetMetersTo(from) / 1000);
    }
}