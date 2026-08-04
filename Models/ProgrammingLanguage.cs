using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models;

public class ProgrammingLanguage
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = "Beginner";

    public string Icon { get; set; } = "💻";

    public string Color { get; set; } = "#6c4bdc";

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}