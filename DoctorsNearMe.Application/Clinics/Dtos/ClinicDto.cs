using NetTopologySuite.Geometries;
using DoctorsNearMe.Application.Users.Dtos;
using DoctorsNearMe.Data.Entities;

namespace DoctorsNearMe.Application.Clinics.Dtos;

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
