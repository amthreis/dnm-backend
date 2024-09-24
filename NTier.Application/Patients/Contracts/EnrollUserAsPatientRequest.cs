using System.ComponentModel.DataAnnotations;

namespace NTier.Application.Patients.Contracts;

public record EnrollUserAsPatientRequest
{
    [Required]
    public Guid UserId { get; set; }
}
