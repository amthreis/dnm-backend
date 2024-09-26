using DoctorsNearMe.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace DoctorsNearMe.Application.Doctors.Contracts;

public record EnrollUserAsDoctorRequest
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public List<DoctorSpecialty> Specialties { get; set; } = new();
}
