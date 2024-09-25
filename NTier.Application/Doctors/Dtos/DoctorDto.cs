using NTier.Data.Entities;
using System.Text.Json.Serialization;

namespace NTier.Application.Users.Dtos;

/*
public record DoctorDto(
    UserDto User,
    [JsonConverter(typeof(JsonStringEnumConverter))]
    List<DoctorSpecialty> Specialties)
{
    public static DoctorDto FromEntity(Doctor doctor)
    {
        return new DoctorDto(
            UserDto.FromEntity(doctor.User),
            doctor.Specialties);
    }
}



*/

public record DoctorDto
{
    public UserDto User { get; }

    public List<DoctorSpecialty> Specialties { get; } = new();

    public DoctorDto(
        UserDto user,
        List<DoctorSpecialty> specialties)
    {
        User = user;
        Specialties = specialties;
    }

    public static DoctorDto FromEntity(Doctor doctor)
    {
        return new DoctorDto(
            UserDto.FromEntity(doctor.User),
            doctor.Specialties);
    }
} 
