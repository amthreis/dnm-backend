using DoctorsNearMe.Application.Clinics.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DoctorsNearMe.Application.Clinics.Contracts;

public record CreateClinicRequest
{
    [Required]
    [DefaultValue("Clinic")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Length(2, 2)]
    [DefaultValue(new double[2] { -22.75026077451582, -43.43522631274805 })]
    public double[] Coords { get; set; } = default!;

    [Required]
    public string JuridicalPersonId { get; set; } = default!;

    [JsonIgnore]
    public LongLat LongLat => new LongLat(Coords[1], Coords[0]);
}
