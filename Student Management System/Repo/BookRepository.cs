using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Repo
{
    public class BookRepository : IBookRepository
    {
            private readonly AppDbContext _context;

            public BookRepository(AppDbContext context)
            {
                _context = context;
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
        }
    }

