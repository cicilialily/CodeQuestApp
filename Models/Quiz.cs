using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models;

public class Quiz
{
    public int Id { get; set; }

    [Required]
    public string Question { get; set; } = string.Empty;

    [Required]
    public string OptionA { get; set; } = string.Empty;

    [Required]
    public string OptionB { get; set; } = string.Empty;

    [Required]
    public string OptionC { get; set; } = string.Empty;

    [Required]
    public string OptionD { get; set; } = string.Empty;

    [Required]
    public string CorrectAnswer { get; set; } = string.Empty;

    public int LessonId { get; set; }

    public Lesson? Lesson { get; set; }
}