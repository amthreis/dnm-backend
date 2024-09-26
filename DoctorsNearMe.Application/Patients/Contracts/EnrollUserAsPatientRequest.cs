using System.ComponentModel.DataAnnotations;

namespace DoctorsNearMe.Application.Patients.Contracts;

public record EnrollUserAsPatientRequest
{
    [Required]
    public Guid UserId { get; set; }
}
