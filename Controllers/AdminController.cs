using Microsoft.AspNetCore.Mvc;
using Tourism_App.Data;
using Tourism_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Tourism_App.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var adminViewModel = new AdminViewModel
        {
            Destinations = _context.Destinations.ToList(),
            Bookings = _context.Bookings.Include(b => b.Destination).Include(b => b.User).ToList(),
            TotalDestinations = _context.Destinations.Count(),
            TotalBookings = _context.Bookings.Count(),
            TotalRevenue = _context.Bookings.Sum(b => b.TotalCost)
        };

        return View(adminViewModel);
    }

    public IActionResult Bookings()
    {
        var bookings = _context.Bookings
            .Include(b => b.Destination)
            .Include(b => b.User)
            .ToList();
        return View(bookings);
    }

    public IActionResult Destinations()
    {
        var destinations = _context.Destinations.ToList();
        return View(destinations);
    }

    public IActionResult Users()
    {
        var users = _context.Users.ToList();
        return View(users);
    }
}

public class AdminViewModel
{
    public IEnumerable<Destination> Destinations { get; set; } = new List<Destination>();
    public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
    public int TotalDestinations { get; set; }
    public int TotalBookings { get; set; }
    public decimal TotalRevenue { get; set; }
}
