using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    [Authorize]
    public class UniversityUpdatesController : Controller
    {
        private readonly AppDbContext _context;

        public UniversityUpdatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UniversityUpdates
        public async Task<IActionResult> Index()
        {
              return _context.UniversityUpdate != null ? 
                          View(await _context.UniversityUpdate.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.UniversityUpdate'  is null.");
        }

        // GET: UniversityUpdates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniversityUpdate == null)
            {
                return NotFound();
            }

            var universityUpdate = await _context.UniversityUpdate
                .FirstOrDefaultAsync(m => m.UpdateId == id);
            if (universityUpdate == null)
            {
                return NotFound();
            }

            return View(universityUpdate);
        }
       
        // GET: UniversityUpdates/Create
        [Authorize(Roles = "Admin,Advisor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniversityUpdates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UpdateId,UpdateName,Description,Date,Image")] UniversityUpdate universityUpdate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universityUpdate);
        }

        // GET: UniversityUpdates/Edit/5
        [Authorize(Roles = "Admin,Advisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniversityUpdate == null)
            {
                return NotFound();
            }

            var universityUpdate = await _context.UniversityUpdate.FindAsync(id);
            if (universityUpdate == null)
            {
                return NotFound();
            }
            return View(universityUpdate);
        }

        // POST: UniversityUpdates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Advisor")]
        public async Task<IActionResult> Edit(int id, [Bind("UpdateId,UpdateName,Description,Date,Image")] UniversityUpdate universityUpdate)
        {
            if (id != universityUpdate.UpdateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityUpdateExists(universityUpdate.UpdateId))
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
            return View(universityUpdate);
        }

        // GET: UniversityUpdates/Delete/5
        [Authorize(Roles = "Admin,Advisor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniversityUpdate == null)
            {
                return NotFound();
            }

            var universityUpdate = await _context.UniversityUpdate
                .FirstOrDefaultAsync(m => m.UpdateId == id);
            if (universityUpdate == null)
            {
                return NotFound();
            }

            return View(universityUpdate);
        }

        // POST: UniversityUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Advisor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniversityUpdate == null)
            {
                return Problem("Entity set 'AppDbContext.UniversityUpdate'  is null.");
            }
            var universityUpdate = await _context.UniversityUpdate.FindAsync(id);
            if (universityUpdate != null)
            {
                _context.UniversityUpdate.Remove(universityUpdate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityUpdateExists(int id)
        {
          return (_context.UniversityUpdate?.Any(e => e.UpdateId == id)).GetValueOrDefault();
        }
    }
}
