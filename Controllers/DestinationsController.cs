using Microsoft.AspNetCore.Mvc;
using Tourism_App.Models;
using Tourism_App.Data;

namespace Tourism_App.Controllers;

public class DestinationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DestinationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var destinations = _context.Destinations.ToList();
        return View(destinations);
    }

    public IActionResult Details(int id)
    {
        var destination = _context.Destinations.FirstOrDefault(d => d.Id == id);
        if (destination == null)
        {
            return NotFound();
        }
        return View(destination);
    }
}


