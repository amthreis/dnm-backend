using System.ComponentModel.DataAnnotations;

namespace NTier.Application.Users.Contracts;

public record CreateUserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(4)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MinLength(4)]
    public string Name { get; set; } = string.Empty;
}
