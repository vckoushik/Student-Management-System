using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;
using System.Data;

namespace Student_Management_System.Controllers
{
    public class ResumeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResumeController(AppDbContext context, UserManager<SystemUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize(Roles = "Admin, Advisor")]
        public IActionResult Index()
        {
            var resumes= _context.Resume.ToList();
            return View(resumes);
        }

        public async Task<IActionResult> MyResume()
        {
            var UserId = GetUserId();
            return _context.Resume != null ?
                        View(await _context.Resume.Where(a => a.UserId == UserId).ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Resume'  is null.");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var resume = _context.Resume
                     .Include(r => r.Education)
                     .Include(r => r.Experiences)
                     .Include(r => r.Skills)
                     .Include(r => r.Certifications)
                     .Include(r=>r.Projects)
                     .Where(r => r.Id == id)
                     .FirstOrDefault();
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var resume = _context.Resume
                     .Include(r => r.Education)
                     .Include(r => r.Experiences)
                     .Include(r => r.Skills)
                     .Include(r => r.Certifications)
                     .Include(r => r.Projects)
                     .Where(r => r.Id == id)
                     .FirstOrDefault();
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        public IActionResult Export(int id)
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
           
            using var PDF = Renderer.RenderUrlAsPdf("https://localhost:7250/Resume/Print/" + id);
            var contentLength = PDF.BinaryData.Length;
            Response.Headers["Content-Length"] = contentLength.ToString();
            var docname = "RESUME_" + id;
            Response.Headers.Add("Content-Disposition", "inline: filename=Document_" + docname + ".pdf");
            
            return File(PDF.BinaryData,"application/pdf;");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Resume resume)
        {
            resume.UserId = GetUserId();
            // Save Resume
            _context.Resume.Add(resume);
            _context.SaveChanges();
            // Save related entities
            foreach(var exp in resume.Experiences)
            {
                exp.Id = 0;
            }
            foreach (var ed in resume.Education)
            {
                ed.Id = 0;
            }
            foreach (var skill in resume.Skills)
            {
                skill.Id = 0;
            }
            foreach (var cert in resume.Certifications)
            {
                cert.Id = 0;
            }
            foreach (var proj in resume.Projects)
            {
                proj.Id = 0;
            }
            _context.Education.AddRange(resume.Education);
            _context.Experience.AddRange(resume.Experiences);
            _context.Skill.AddRange(resume.Skills);
            _context.Certification.AddRange(resume.Certifications);
            _context.Project.AddRange(resume.Projects);
            // Set IDENTITY_INSERT back to OFF
            
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        private string GetUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = _userManager.GetUserId(user);
            return userId;

        }
    }
}
