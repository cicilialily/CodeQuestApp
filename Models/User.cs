using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "Child";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int XP { get; set; } = 0;

    public int Level { get; set; } = 1;
}