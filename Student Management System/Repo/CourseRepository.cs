using Microsoft.AspNetCore.Identity;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Repo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CourseRepository(AppDbContext context, UserManager<SystemUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = contextAccessor;
        }

        public IEnumerable<Course>  GetAllCourses()
        {
            return _context.Course.ToList();
        }

        public Course GetCourseById(int? id)
        {
            return _context.Course.FirstOrDefault(c=>c.Id == id);
        }

    }
}
