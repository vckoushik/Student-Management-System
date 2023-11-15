using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class BorrowBooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BorrowBooksController(AppDbContext context, UserManager<SystemUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: BorrowBooks
        public async Task<IActionResult> Index()
        {
              return _context.BorrowBooks != null ? 
                          View(await _context.BorrowBooks.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.BorrowBooks'  is null.");
        }
        public async Task<IActionResult> StudentRequest()
        {
            var UserId = GetUserId();
            return _context.BorrowBooks != null ?
                        View(await _context.BorrowBooks.Where(b=>b.UserId==UserId).ToListAsync()) :
                        Problem("Entity set 'AppDbContext.BorrowBooks'  is null.");
        }

        // GET: BorrowBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowBooks == null)
            {
                return NotFound();
            }

            var borrowBook = await _context.BorrowBooks
                .FirstOrDefaultAsync(m => m.BorrowID == id);
            if (borrowBook == null)
            {
                return NotFound();
            }

            return View(borrowBook);
        }

        // GET: BorrowBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BorrowBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowID,BorrowDate,ReturnDate,Status,UserId")] BorrowBook borrowBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(borrowBook);
        }

        // GET: BorrowBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowBooks == null)
            {
                return NotFound();
            }

            var borrowBook = await _context.BorrowBooks.FindAsync(id);
            if (borrowBook == null)
            {
                return NotFound();
            }
            return View(borrowBook);
        }

        // POST: BorrowBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowID,BorrowDate,ReturnDate,RequestStatus,UserId")] BorrowBook borrowBook)
        {
            if (id != borrowBook.BorrowID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowBookExists(borrowBook.BorrowID))
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
            return View(borrowBook);
        }

        // GET: BorrowBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowBooks == null)
            {
                return NotFound();
            }

            var borrowBook = await _context.BorrowBooks
                .FirstOrDefaultAsync(m => m.BorrowID == id);
            if (borrowBook == null)
            {
                return NotFound();
            }

            return View(borrowBook);
        }

        // POST: BorrowBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowBooks == null)
            {
                return Problem("Entity set 'AppDbContext.BorrowBooks'  is null.");
            }
            var borrowBook = await _context.BorrowBooks.FindAsync(id);
            if (borrowBook != null)
            {
                _context.BorrowBooks.Remove(borrowBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> BookRequest(int? id)
        {
            BorrowBook borrowBook = new BorrowBook();
            borrowBook.BorrowDate = DateTime.Now;
            borrowBook.RequestStatus = "Pending";
            borrowBook.ReturnDate = borrowBook.BorrowDate.AddDays(15);
            borrowBook.UserId = GetUserId();
            borrowBook.BookNo = id ?? default(int);
            return View(borrowBook);
        }

        //BorrowBooks/BorrowBook/5
        public async Task<IActionResult> BorrowBook(int bookNumber)
        {
            if (_context.BorrowBooks == null)
            {
                return Problem("Entity set 'AppDbContext.BorrowBooks'  is null.");
            }
            var book = _context.Book.Find(bookNumber);
          
            BorrowBook borrowBook = new BorrowBook();
            borrowBook.BorrowDate = DateTime.Now;
            //borrowBook.Status = false;
            borrowBook.RequestStatus = "Pending";
            borrowBook.UserId = GetUserId();
            borrowBook.BookNo = bookNumber;

            borrowBook.ReturnDate = borrowBook.BorrowDate.AddDays(15);

            _context.BorrowBooks.Add(borrowBook);

            await _context.SaveChangesAsync();
            return RedirectToAction("LibraryIndex","Library");
        }

        private bool BorrowBookExists(int id)
        {
          return (_context.BorrowBooks?.Any(e => e.BorrowID == id)).GetValueOrDefault();
        }
        private string GetUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = _userManager.GetUserId(user);
            return userId;

        }
    }
}
