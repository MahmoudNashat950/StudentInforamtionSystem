using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

[Authorize(Roles = "Admin,Staff,Student")]
public class TranscriptsController : Controller
{
    private readonly UniversityContext _context;

    public TranscriptsController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
      

        var allTranscripts = await _context.Transcripts
            .Include(t => t.Student)
            .ToListAsync();

        return View(allTranscripts);
    }
}
