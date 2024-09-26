using NetTopologySuite.Geometries;
using DoctorsNearMe.Application.Users.Dtos;
using DoctorsNearMe.Data.Entities;

namespace DoctorsNearMe.Application.Clinics.Dtos;

public record ClinicNearMeDto(
    UserDto User,
    string Name,
    double Distance)
{

    public static ClinicNearMeDto FromEntity(Clinic clinic, Point from)
    {
        return new ClinicNearMeDto(
            UserDto.FromEntity(clinic.User),
            clinic.Name,
            clinic.GetMetersTo(from) / 1000);
    }
}