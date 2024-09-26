using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DoctorsNearMe.Data.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AppointmentReviewScore
{
    Negative,
    Neutral,
    Positive
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AppointmentState
{
    BeforeConfirmation,
    AfterConfirmation,
    Ongoing,
    Cancelled,
    Over
}

public class Appointment
{
    public int Id { get; set; }
    public Guid PublicId { get; set; } = Guid.NewGuid();

    public Clinic Clinic { get; set; } = default!;

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Doctor Doctor { get; set; } = default!;

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Patient Patient { get; set; } = default!;

    public string PatientCode { get; set; } = "0000";

    public DateTime CreatedAt { get; set; }
    public DateTime? AttendedAt { get; set; }
    public DateTime? StartsAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public DateTime? ReviewedAt { get; set; }

    [Column(TypeName = "TEXT")]
    public AppointmentState State { get; set; } = AppointmentState.BeforeConfirmation;

    [Column(TypeName = "TEXT")]
    public AppointmentReviewScore ReviewScore { get; set; } = AppointmentReviewScore.Neutral;

    [Length(2, 450)]
    public string? ReviewContent { get; set; }

}