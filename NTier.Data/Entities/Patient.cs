using System.ComponentModel.DataAnnotations.Schema;

namespace NTier.Data.Entities;

public class Patient
{
    [ForeignKey("Id")]
    public User User { get; set; } = default!;
}
