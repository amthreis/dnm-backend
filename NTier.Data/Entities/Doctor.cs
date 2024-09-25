using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NTier.Data.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DoctorSpecialty
{
    Dermatology,
    Psychiatry,
    Pediatrics,
}

public class Doctor
{
    [ForeignKey("Id")]
    public User User { get; set; } = default!;

    [Column(TypeName = "TEXT")]
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public List<DoctorSpecialty> Specialties { get; set; } = new();
}
