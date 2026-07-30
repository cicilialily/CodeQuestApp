using CodeQuest.Data;
using CodeQuest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeQuest.Controllers;

public class SeedController : Controller
{
    private readonly AppDbContext _context;

    public SeedController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Languages()
    {
        if (!_context.ProgrammingLanguages.Any())
        {
            _context.ProgrammingLanguages.AddRange(

                new ProgrammingLanguage
                {
                    Name = "Python",
                    Description = "Learn programming with fun and easy lessons.",
                    Difficulty = "Beginner",
                    Icon = "🐍",
                    Color = "#3776AB"
                },

                new ProgrammingLanguage
                {
                    Name = "HTML",
                    Description = "Build your first web pages.",
                    Difficulty = "Beginner",
                    Icon = "🌐",
                    Color = "#E34F26"
                },

                new ProgrammingLanguage
                {
                    Name = "CSS",
                    Description = "Make your websites beautiful.",
                    Difficulty = "Beginner",
                    Icon = "🎨",
                    Color = "#1572B6"
                },

                new ProgrammingLanguage
                {
                    Name = "JavaScript",
                    Description = "Bring websites to life.",
                    Difficulty = "Intermediate",
                    Icon = "⚡",
                    Color = "#F7DF1E"
                },

                new ProgrammingLanguage
                {
                    Name = "C#",
                    Description = "Create desktop and web applications.",
                    Difficulty = "Intermediate",
                    Icon = "#️⃣",
                    Color = "#68217A"
                },

                new ProgrammingLanguage
                {
                    Name = "Java",
                    Description = "Learn object-oriented programming.",
                    Difficulty = "Advanced",
                    Icon = "☕",
                    Color = "#F89820"
                }

            );

            _context.SaveChanges();
        }

        return Content("Programming languages added successfully!");
    }
}