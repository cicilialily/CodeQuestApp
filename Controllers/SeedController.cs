using CodeQuest.Data;
using CodeQuest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CodeQuest.Controllers
{
    public class SeedController : Controller
    {
        private readonly AppDbContext _context;

        public SeedController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Languages()
        {
            // ============================
            // Add Programming Languages
            // ============================
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

            // ============================
            // Find Python
            // ============================

            var python = _context.ProgrammingLanguages
                .FirstOrDefault(p => p.Name == "Python");

            if (python != null)
            {
                // ============================
                // Lesson 1
                // ============================

                if (!_context.Lessons.Any(l =>
                    l.ProgrammingLanguageId == python.Id &&
                    l.LessonNumber == 1))
                {
                    _context.Lessons.Add(new Lesson
                    {
                        Title = "What is Programming?",
                        LessonNumber = 1,
                        ProgrammingLanguageId = python.Id,

                        Content = @"Programming means giving instructions to a computer.

Imagine you have a robot friend 🤖.

If you tell the robot to wave, it waves.

If you tell it to dance, it dances.

Programming languages help us give instructions to computers.",

                        FunFact = "Python is named after a comedy TV show, not the snake!"
                    });
                }

                // ============================
                // Lesson 2
                // ============================

                if (!_context.Lessons.Any(l =>
                    l.ProgrammingLanguageId == python.Id &&
                    l.LessonNumber == 2))
                {
                    _context.Lessons.Add(new Lesson
                    {
                        Title = "Your First Python Program",
                        LessonNumber = 2,
                        ProgrammingLanguageId = python.Id,

                        Content = @"Every programming language starts with a simple program.

In Python we can write:

print(""Hello, World!"")

The computer will display:

Hello, World!",

                        FunFact = "Almost every programmer starts with 'Hello, World!'"
                    });
                }

                _context.SaveChanges();
            }

            // ============================
            // Add Quiz
            // ============================

            var lesson1 = _context.Lessons
                .FirstOrDefault(l => l.LessonNumber == 1);

            if (lesson1 != null)
            {
                if (!_context.Quizzes.Any(q => q.LessonId == lesson1.Id))
                {
                    _context.Quizzes.Add(new Quiz
                    {
                        LessonId = lesson1.Id,

                        Question = "Which of these is a programming language?",

                        OptionA = "Football",

                        OptionB = "Python",

                        OptionC = "Banana",

                        OptionD = "Television",

                        CorrectAnswer = "Python"
                    });

                    _context.SaveChanges();
                }
            }

            return Content("Programming languages, lessons and quizzes have been added successfully!");
        }
    }
}