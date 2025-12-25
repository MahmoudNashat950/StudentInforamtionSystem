using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

[Authorize(Roles = "Student")]
public class EventsController : Controller
{
    private readonly UniversityContext _context;
    public EventsController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Events.OrderBy(e => e.EventDate).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Event evt)
    {
        if (ModelState.IsValid)
        {
            _context.Add(evt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(evt);
    }
}
