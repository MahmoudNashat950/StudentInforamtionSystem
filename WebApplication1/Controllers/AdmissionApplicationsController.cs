using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

[Authorize(Roles = "Admin,Staff")]
public class AdmissionApplicationsController : Controller
{
    private readonly UniversityContext _context;

    public AdmissionApplicationsController(UniversityContext context)
    {
        _context = context;
    }

    // GET: Admin can view all applications
    public async Task<IActionResult> Index()
    {
        return View(await _context.AdmissionApplications.ToListAsync());
    }

    // GET: Create new application (open for public)
    [AllowAnonymous]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(AdmissionApplication application)
    {
        if (ModelState.IsValid)
        {
            application.ApplicationStatus = "Pending";
            _context.Add(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("ThankYou");
        }
        return View(application);
    }

    // GET: Admin approves/rejects
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var app = await _context.AdmissionApplications.FindAsync(id);
        if (app == null) return NotFound();
        return View(app);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, AdmissionApplication application)
    {
        if (id != application.ApplicationId) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(application);
    }

    public IActionResult ThankYou()
    {
        return View();
    }
}
