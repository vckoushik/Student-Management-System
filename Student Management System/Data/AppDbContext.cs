
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Student_Management_System.Models;

namespace Student_Management_System.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }

        //config need to add rows to tables
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20
            });
            builder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40
            });

        }   */


        public DbSet<Book> Book { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CareerAdvisor> CareerAdvisor { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<UniversityUpdate> UniversityUpdate { get; set; }

    }
}
