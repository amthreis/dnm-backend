using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace NTier.Data.Entities;

//public record PatientCode
//{
//    public string Value { get; } = "0000";

//    PatientCode(string value)
//    {
//        if (value == null)
//            throw new ArgumentNullException("Patient code can't be null");

//        if (Regex.IsMatch(value, @"^\d{4}$"))
//            throw new ArgumentNullException("Patient code must be a number of 4 digits");

//        Value = value;
//    }
//}

public class Patient
{
    [ForeignKey("Id")]
    public User User { get; set; } = default!;

    public string Code { get; set; } = default!;
}
