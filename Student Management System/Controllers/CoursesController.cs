using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoursesController(AppDbContext context, UserManager<SystemUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
           _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
              return _context.Course != null ? 
                          View(await _context.Course.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Course'  is null.");
        }

        public async Task<IActionResult> AvailableCourses()
        {
            return _context.Course != null ?
                        View(await _context.Course.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Course'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Status,EnrollmentCount,TotalSeats,RoomNumber,Timings,ProfessorName")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Status,EnrollmentCount,TotalSeats,RoomNumber,Timings,ProfessorName")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> RegisteredCourses()
        {
            var UserId = GetUserId();
            return _context.Course != null ?
                        View(await _context.CourseRegistration.Where(c=>c.UserId == UserId).ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Course'  is null.");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Course == null)
            {
                return Problem("Entity set 'AppDbContext.Course'  is null.");
            }
            var course = await _context.Course.FindAsync(id);
            if (course != null)
            {
                _context.Course.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddCourse(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("AddCourse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse(int id)
        {
            if (_context.Course == null)
            {
                return Problem("Entity set 'AppDbContext.Course'  is null.");
            }
            var UserId = GetUserId();
            var course = await _context.Course.FindAsync(id);
            if (_context.CourseRegistration.Any(cr => cr.UserId == UserId && cr.CourseId == id))
            {
                // Handle the case where the student is already registered for the course
                return BadRequest("Student is already registered for the course.");
            }
            if (course != null)
            {
               
                CourseRegistration courseRegistration = new CourseRegistration()
                {
                    UserId = UserId,
                    CourseId = course.Id,
                    Course = course,
                    RegistrationDate = DateTime.Now


                };
                _context.CourseRegistration.Add(courseRegistration);
            }
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DropClass(int Id)
        {
            try
            {
              

                if (Id == null)
                {
                    // Handle the case where the student or course does not exist
                    return NotFound("Student or Course not found.");
                }

                // Check if the student is registered for the course
                var registration = _context.CourseRegistration
                    .FirstOrDefault(cr => cr.Id ==Id);

                if (registration == null)
                {
                    // Handle the case where the student is not registered for the course
                    return BadRequest("Student is not registered for the course.");
                }

                // Remove the registration from the context and save changes
                _context.CourseRegistration.Remove(registration);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home"); // Redirect to a relevant page after successful drop
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private bool CourseExists(int id)
        {
          return (_context.Course?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private string GetUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = _userManager.GetUserId(user);
            return userId;

        }
    }
}
