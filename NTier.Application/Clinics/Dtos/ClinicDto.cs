using NetTopologySuite.Geometries;
using NTier.Data.Entities;

namespace NTier.Application.Clinics.Dtos;

public record ClinicDto(int Id, Guid PublicId, string Name, Point Location)
{
    public static ClinicDto FromEntity(Clinic clinic)
    {
        return new ClinicDto(
            clinic.Id,
            clinic.PublicId,
            clinic.Name,
            clinic.Location);
    }
}
