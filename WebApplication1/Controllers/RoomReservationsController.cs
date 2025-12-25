using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.UniversityModels;

namespace WebApplication1.Controllers
{
    public class RoomReservationsController : Controller
    {
        private readonly UniversityContext _context;

        public RoomReservationsController(UniversityContext context)
        {
            _context = context;
        }

        // Students, Admin, Staff can view the list
        [Authorize] // any logged-in user can view
        public async Task<IActionResult> Index()
        {
            var reservations = _context.RoomReservations
                .Include(r => r.Classroom)
                .OrderBy(r => r.StartTime);
            return View(await reservations.ToListAsync());
        }

        // Only Admin and Staff can create
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create(int? classroomId)
        {
            ViewData["ClassroomId"] = new SelectList(
                _context.Classrooms, "ClassroomId", "RoomNumber", classroomId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Create(RoomReservation reservation)
        {
            if (ModelState.IsValid)
            {
                // Check for conflicts
                bool conflict = _context.RoomReservations.Any(r =>
                    r.ClassroomId == reservation.ClassroomId &&
                    r.StartTime < reservation.EndTime &&
                    r.EndTime > reservation.StartTime);

                if (conflict)
                {
                    ModelState.AddModelError("", "This room is already reserved in this time slot.");
                    ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "RoomNumber", reservation.ClassroomId);
                    return View(reservation);
                }

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "RoomNumber", reservation.ClassroomId);
            return View(reservation);
        }
    }
}
