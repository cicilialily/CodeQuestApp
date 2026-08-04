using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models;

public class Lesson
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public string FunFact { get; set; } = string.Empty;

    public int LessonNumber { get; set; }

    public int ProgrammingLanguageId { get; set; }

    public ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}