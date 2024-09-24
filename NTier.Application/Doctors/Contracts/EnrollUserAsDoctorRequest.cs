using NTier.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace NTier.Application.Doctors.Contracts;

public record EnrollUserAsDoctorRequest
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public List<DoctorSpecialty> Specialties { get; set; } = new();
}
