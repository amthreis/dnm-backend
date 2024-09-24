using NTier.Data.Entities;

namespace NTier.Application.Users.Dtos;

public record DoctorDto(
    UserDto User,
    List<DoctorSpecialty> Specialties)
{
    public static DoctorDto FromEntity(Doctor doctor)
    {
        return new DoctorDto(
            UserDto.FromEntity(doctor.User),
            doctor.Specialties);
    }
}
