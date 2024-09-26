using DoctorsNearMe.Application.Clinics.Dtos;
using DoctorsNearMe.Application.Users.Dtos;
using DoctorsNearMe.Data.Entities;
using System.Text.Json.Serialization;

namespace DoctorsNearMe.Application.Appointments.Dtos;

public record AppointmentDto
{
    public int Id { get; }
    public Guid PublicId { get; }

    public ClinicDto Clinic { get; }
    public DoctorDto Doctor { get; }
    public PatientDto Patient { get; }

    public string PatientCode { get; }

    public DateTime CreatedAt { get; }
    public DateTime? AttendedAt { get; }
    public DateTime? StartsAt { get; }
    public DateTime? CancelledAt { get; }
    public DateTime? EndedAt { get; }
    public DateTime? ReviewedAt { get; }

    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public AppointmentState State { get; } = AppointmentState.BeforeConfirmation;

    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public AppointmentReviewScore ReviewScore { get; }

    public string? ReviewContent { get; }

    AppointmentDto(
        int id,
        Guid publicId,

        ClinicDto clinic,
        DoctorDto doctor,

        PatientDto patient,
        string patientCode,

        DateTime createdAt,
        DateTime? attendedAt,
        DateTime? startsAt,
        DateTime? cancelledAt,
        DateTime? endedAt,
        DateTime? reviewedAt,
        
        AppointmentState state,
        AppointmentReviewScore reviewScore,

        string? reviewContent)
    {
        Id = id;
        PublicId = publicId;
        Clinic = clinic;
        Patient = patient;
        PatientCode = patientCode;
        Doctor = doctor;
        CreatedAt = createdAt;
        AttendedAt = attendedAt;
        StartsAt = startsAt;
        CancelledAt = cancelledAt;
        EndedAt = endedAt;
        ReviewedAt = reviewedAt;
        State = state;
        ReviewScore = reviewScore;
        ReviewContent = reviewContent;
    }

    public static AppointmentDto FromEntity(Appointment appt)
    {
        return new AppointmentDto(
            appt.Id,
            appt.PublicId,

            ClinicDto.FromEntity(appt.Clinic),
            DoctorDto.FromEntity(appt.Doctor),
            PatientDto.FromEntity(appt.Patient),
            appt.PatientCode,

            appt.CreatedAt,
            appt.AttendedAt,
            appt.StartsAt,
            appt.CancelledAt,
            appt.EndedAt,
            appt.ReviewedAt,

            appt.State,

            appt.ReviewScore,
            appt.ReviewContent
        );
    }
}