using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

[Authorize(Roles = "Admin,Staff")]
public class StudentRecordsController : Controller
{
    private readonly UniversityContext _context;

    public StudentRecordsController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Trainees.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var student = await _context.Trainees.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var student = await _context.Trainees.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Trainee student)
    {
        if (id != student.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }
}
