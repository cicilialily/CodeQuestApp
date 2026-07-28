using BCrypt.Net;
using CodeQuest.Data;
using CodeQuest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }


   

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(
        string fullName,
        string email,
        string password)
    {
        if (string.IsNullOrWhiteSpace(fullName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            ViewBag.Error = "Please fill in all fields.";
            return View();
        }



        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        if (existingUser != null)
        {
            ViewBag.Error = "An account with this email already exists.";
            return View();
        }



        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);



        var user = new User
        {
            FullName = fullName,
            Email = email,
            PasswordHash = passwordHash,
            Role = "Child",
            XP = 0,
            Level = 1,
            CreatedAt = DateTime.UtcNow
        };



        _context.Users.Add(user);

        await _context.SaveChangesAsync();



        return RedirectToAction("Login");
    }


    

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(
        string email,
        string password)
    {
        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            ViewBag.Error = "Please enter your email and password.";
            return View();
        }



        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);



        if (user == null ||
            !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            ViewBag.Error = "Invalid email or password.";
            return View();
        }



        HttpContext.Session.SetInt32("UserId", user.Id);

        HttpContext.Session.SetString(
            "UserName",
            user.FullName
        );



        return RedirectToAction(
            "Index",
            "Dashboard"
        );
    }


   
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction(
            "Index",
            "Home"
        );
    }
}