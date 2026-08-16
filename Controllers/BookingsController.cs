using Microsoft.AspNetCore.Mvc;
using Tourism_App.Models;
using Tourism_App.Data;
using Microsoft.EntityFrameworkCore;

namespace Tourism_App.Controllers;

public class BookingsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }



    [HttpGet]
    public IActionResult Create(int destinationId)
    {
        // Check if user is logged in
        if (HttpContext.Session.GetString("UserId") == null)
        {
            return RedirectToAction("Login", "Account");
        }

        // Get destination details to pre-populate pricing
        var destination = _context.Destinations.FirstOrDefault(d => d.Id == destinationId);

        if (destination == null)
        {
            return NotFound();
        }

        var booking = new Booking
        {
            DestinationId = destinationId,
            ChargePerPerson = destination.Price,
            NumberOfPeople = 1 // Default to 1 person
        };

        ViewBag.Destination = destination;
        return View(booking);
    }

    [HttpPost]
    public IActionResult Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            // Get current user from session
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Account");
            }

            booking.UserId = int.Parse(userIdString);

            // Calculate total cost
            var destination = _context.Destinations.FirstOrDefault(d => d.Id == booking.DestinationId);
            if (destination != null)
            {
                booking.ChargePerPerson = destination.Price;
                booking.TotalCost = booking.NumberOfPeople * booking.ChargePerPerson;
            }

            // Save booking to database
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Confirm", new { id = booking.Id });
        }

        var destinationForView = _context.Destinations.FirstOrDefault(d => d.Id == booking.DestinationId);
        ViewBag.Destination = destinationForView;
        return View(booking);
    }

    public IActionResult Confirm(int id)
    {
        var booking = _context.Bookings
            .Include(b => b.Destination)
            .FirstOrDefault(b => b.Id == id);

        if (booking == null)
        {
            return NotFound();
        }

        ViewBag.Message = "Your booking has been registered! Our team will call you shortly for further information.";
        return View(booking);
    }
}
