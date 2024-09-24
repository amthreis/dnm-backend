using NTier.Data.Entities;

namespace NTier.Application.Users.Dtos;

public record PatientDto(UserDto user)
{
    public static PatientDto FromEntity(Patient patient)
    {
        return new PatientDto(
            UserDto.FromEntity(patient.User));
    }
}
