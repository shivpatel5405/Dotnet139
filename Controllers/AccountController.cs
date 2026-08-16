using Microsoft.AspNetCore.Mvc;
using Tourism_App.Data;
using Tourism_App.Models;

namespace Tourism_App.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            // Store user in session (simplified - in real app use proper authentication)
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

            if (user.IsAdmin)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        ViewBag.Error = "Invalid username or password";
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user, string confirmPassword)
    {
        if (ModelState.IsValid)
        {
            // Check if user already exists
            if (_context.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
            {
                ViewBag.Error = "Username or email already exists";
                return View(user);
            }

            // Check password confirmation
            if (user.Password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View(user);
            }

            // Add new user to database
            user.CreatedDate = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();

            // Log the user registration
            System.Diagnostics.Debug.WriteLine($"[REGISTRATION LOG] New user registered: {user.Username} ({user.Email}) at {DateTime.Now}");

            // Redirect to login page instead of auto-login
            TempData["SuccessMessage"] = "Registration successful! Please login to continue.";
            return RedirectToAction("Login", "Account");
        }

        return View(user);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    // Helper method to get current user
    public static User? GetCurrentUser(HttpContext httpContext, ApplicationDbContext context)
    {
        var userId = httpContext.Session.GetString("UserId");
        if (int.TryParse(userId, out int id))
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
        return null;
    }
}
