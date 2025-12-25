using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

public class MaintenanceRequestsController : Controller
{
    private readonly UniversityContext _context;

    public MaintenanceRequestsController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var data = _context.MaintenanceRequests
            .Include(m => m.Classroom);

        return View(await data.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["ClassroomId"] = new SelectList(
            _context.Classrooms, "ClassroomId", "RoomNumber");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MaintenanceRequest request)
    {
        if (ModelState.IsValid)
        {
            request.Status = "Open";
            _context.MaintenanceRequests.Add(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(request);
    }
}
