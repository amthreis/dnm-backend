using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NTier.Data.Entities;

namespace DoctorsNearMe;

public enum AppointmentReviewScore
{
    Negative,
    Neutral,
    Positive
}

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

    //public Clinic Clinic { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Doctor Doctor { get; set; } = default!;

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Patient Patient { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public DateTime? ReviewedAt { get; set; }

    [Column(TypeName = "TEXT")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppointmentState State { get; set; } = AppointmentState.BeforeConfirmation;

    [Column(TypeName = "TEXT")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppointmentReviewScore ReviewScore { get; set; } = AppointmentReviewScore.Neutral;

    [Length(2, 450)]
    public string? ReviewContent { get; set; }

}