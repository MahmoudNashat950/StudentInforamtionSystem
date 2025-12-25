using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

public class ClassroomsController : Controller
{
    private readonly UniversityContext _context;

    public ClassroomsController(UniversityContext context)
    {
        _context = context;
    }

    // GET: Classrooms
    public async Task<IActionResult> Index()
    {
        return View(await _context.Classrooms.ToListAsync());
    }

    // GET: Classrooms/Availability/5
    public IActionResult Availability(int id)
    {
        ViewBag.Room = _context.Classrooms.Find(id);

        var reservations = _context.RoomReservations
            .Where(r => r.ClassroomId == id)
            .OrderBy(r => r.StartTime)
            .ToList();

        return View(reservations);
    }
}
