using Student_Management_System.Models;

namespace Student_Management_System.Repo
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookByBNo(int? bookNumber);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookNumber);

    }
}
