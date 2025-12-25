using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

[Authorize(Roles = "Admin,Staff,Student")]
public class ResourceAllocationsController : Controller
{
    private readonly UniversityContext _context;

    public ResourceAllocationsController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        
        return View(await _context.ResourceAllocations.Include(r => r.Resource).ToListAsync());
    }

    [Authorize(Roles = "Admin,Staff")]
    public IActionResult Create()
    {
        ViewData["ResourceId"] = new SelectList(_context.Resources, "Id", "Name");
        ViewData["TraineeId"] = new SelectList(_context.Trainees, "Id", "FullName");
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Staff")]
    public async Task<IActionResult> Create(ResourceAllocation allocation)
    {
        if (ModelState.IsValid)
        {
            _context.Add(allocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(allocation);
    }
}
