using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Features;

namespace NTier.Data.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }
    public Guid PublicId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty; 
}
