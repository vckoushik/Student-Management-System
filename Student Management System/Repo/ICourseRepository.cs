using Student_Management_System.Models;

namespace Student_Management_System.Repo
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int? id);
    }
}
