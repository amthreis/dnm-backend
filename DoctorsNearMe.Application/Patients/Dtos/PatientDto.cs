using DoctorsNearMe.Data.Entities;

namespace DoctorsNearMe.Application.Users.Dtos;

public record PatientDto(UserDto User, string Code)
{
    public static PatientDto FromEntity(Patient patient)
    {
        return new PatientDto(
            UserDto.FromEntity(patient.User),
            patient.Code);
    }
}
