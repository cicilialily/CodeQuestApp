using CodeQuest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Controllers;

public class LanguageController : Controller
{
    private readonly AppDbContext _context;

    public LanguageController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var languages = await _context.ProgrammingLanguages
            .ToListAsync();

        return View(languages);
    }
}