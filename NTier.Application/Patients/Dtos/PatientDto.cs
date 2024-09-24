using NTier.Data.Entities;

namespace NTier.Application.Users.Dtos;

public record PatientDto(UserDto user)
{
    //public int Id { get; init; }
    //public Guid PublicId { get; init; }
    //public string Name { get; init; } = string.Empty;
    //public string Email { get; init; } = string.Empty;

    PatientDto(Patient patient) 
        : this(new UserDto(patient.User))
    {
        //Id = user.Id;
        //PublicId = user.PublicId;
        //Name = user.Name;
        //Email = user.Email;
    }

    public static PatientDto FromEntity(Patient patient)
    {
        return new PatientDto(patient);
    }
}
