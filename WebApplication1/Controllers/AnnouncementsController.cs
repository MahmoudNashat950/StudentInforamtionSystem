using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

namespace WebApplication1.Controllers
{
   
    public class AnnouncementsController : Controller
    {
        private readonly UniversityContext _context;
        public AnnouncementsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Announcements.OrderByDescending(a => a.CreatedDate).ToListAsync());
        }

        [Authorize(Roles = "Admin,Staff")]

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Staff")]

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        // Optional: Delete or Edit
    }
}
