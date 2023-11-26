using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Repo
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookRepository(AppDbContext context, UserManager<SystemUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = contextAccessor;
        }

            public IEnumerable<Book> GetAllBooks()
            {
                return _context.Book.ToList();
            }

            public Book GetBookByBNo(int? bookNumber)
            {
                return _context.Book.FirstOrDefault(b => b.BNo == bookNumber);
            }

            public void AddBook(Book book)
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book));

                _context.Book.Add(book);
                _context.SaveChanges();
            }

            public void UpdateBook(Book book)
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book));

                _context.Entry(book).State = EntityState.Modified;
                _context.SaveChanges();
            }

            public void DeleteBook(int bookNumber)
            {
                var book = _context.Book.Find(bookNumber);
                if (book != null)
                {
                    _context.Book.Remove(book);
                    _context.SaveChanges();
                }
            }

            public bool BorrowBook(int bookNumber)
            {
                var book = _context.Book.Find(bookNumber);
                if(book == null)
                {
                    return false;
                }

            BorrowBook borrowBook = new BorrowBook();
            borrowBook.BorrowDate = DateTime.Now;
            //borrowBook.Status = false;
            borrowBook.UserId = GetUserId();
            borrowBook.BookNo = bookNumber;
            borrowBook.ReturnDate= borrowBook.BorrowDate.AddDays(15);
            _context.BorrowBooks.Add(borrowBook);
            //borrowBook.Student 
            _context.SaveChangesAsync();
            return true;        
            }
            private string GetUserId()
            {
                var user = _httpContextAccessor.HttpContext.User;
                var userId = _userManager.GetUserId(user);
                return userId;

            }
    }
    }

