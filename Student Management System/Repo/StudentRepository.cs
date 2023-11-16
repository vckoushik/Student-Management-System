using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Repo
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Student.Include(s => s.Address).ToList();
        }

   

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _context.Student.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Student.Find(studentId);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
