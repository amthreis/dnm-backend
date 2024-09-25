using NetTopologySuite.Geometries;
using NTier.Application.Users.Dtos;
using NTier.Data.Entities;

namespace NTier.Application.Clinics.Dtos;

public record ClinicDto(
    UserDto User,
    string Name,
    Point Location)
{
    public static ClinicDto FromEntity(Clinic clinic)
    {
        return new ClinicDto(
            UserDto.FromEntity(clinic.User),
            clinic.Name,
            clinic.Location);
    }
}
