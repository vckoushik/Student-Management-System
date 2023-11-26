using Student_Management_System.Repo;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Moq;
using Student_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Controllers;
using Student_Management_System.Data;
using Microsoft.AspNetCore.Identity;

namespace TestProject
{
    [TestClass]
    public class UnitTest1 
    {
        protected readonly AppDbContext _context;
        public UnitTest1() {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        _context = new AppDbContext(options);
        _context.Database.EnsureCreated();
        }

        [TestMethod]
        [Fact]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var expectedBooks = new List<Book>
            {
                new Book { BNo = 1, BName = "Data Structures and Algorithms Edition 1", Author = "Tony",  Status = "In Stock", AvailableCopies = 0, TotalCopies = 0 },
                new Book { BNo = 2, BName = "Database Systems", Author = "Hector Gracia", Status = "In Stock",  AvailableCopies = 250, TotalCopies = 250 },
               
            };

            mockBookRepository.Setup(x => x.GetAllBooks()).Returns(expectedBooks);

            // Act
            var result = mockBookRepository.Object.GetAllBooks();

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Contains(result, book => book.BName == "Database Systems");
            Xunit.Assert.Contains(result, book => book.Author == "Tony");

        }
        [TestMethod]
        [Fact]
        public void GetBookByBNo_ReturnsCorrectBook()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var expectedBookNumber = 1;
            var expectedBook = new Book { BNo = expectedBookNumber, BName = "Data Structures and Algorithms Edition 1", Author = "Tony"};

            mockBookRepository.Setup(x => x.GetBookByBNo(expectedBookNumber)).Returns(expectedBook);

            // Act
            var result = mockBookRepository.Object.GetBookByBNo(expectedBookNumber);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedBookNumber, result.BNo);
            Xunit.Assert.Equal("Data Structures and Algorithms Edition 1", result.BName);
            Xunit.Assert.Equal("Tony", result.Author);
        }
        [TestMethod]
        [Fact]
        public void GetAllCourses_ReturnsAllCourses()
        {
            // Arrange
            var mock = new Mock<ICourseRepository>();
            var expectedCourseNumber = 1;
            var expectedCourse = new List<Course> { new Course { Id = expectedCourseNumber, Name = "Software Engineering" } };
            mock.Setup(x => x.GetAllCourses()).Returns(expectedCourse);

            // Act
            var result = mock.Object.GetAllCourses();

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Contains(result, c => c.Name == "Software Engineering");

        }
        [TestMethod]
        [Fact]
        public void GetCourseById_ReturnsCorrectCourse()
        {
            // Arrange
            var mock = new Mock<ICourseRepository>();
            var expectedCourseNumber = 1;
            var expectedCourse = new Course { Id = expectedCourseNumber, Name = "Software Engineering" };

            mock.Setup(x => x.GetCourseById(expectedCourseNumber)).Returns(expectedCourse);

            // Act
            var result = mock.Object.GetCourseById(expectedCourseNumber);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedCourseNumber, result.Id);
            Xunit.Assert.Equal("Software Engineering", result.Name);
            
        }


        [TestMethod]
        [Fact]
        public async Task Index_ReturnsViewWithJobs()
        {
            // Arrange
            var controller = new JobsController(_context);

            // Add test jobs to the in-memory database
            var testJobs = new List<Job>
                {
                    new Job
                    {
                        Id = 1,
                        Title = "Senior Data Scientist",
                        Description = "Exciting opportunity for an experienced Data Scientist.",
                        Email = "jobs@example.com",
                        Company = "Tech Solutions Inc.",
                        CompanyLogo = "logo1.png",
                        PostedOn = DateTime.UtcNow.AddDays(-5),
                        LinkToJob = "https://example.com/job/1"
                    },
                    new Job
                    {
                        Id = 2,
                        Title = "Product Manager",
                        Description = "Join our team as a Product Manager and shape the future of our products.",
                        Email = "careers@example.com",
                        Company = "Innovate Tech",
                        CompanyLogo = "logo2.png",
                        PostedOn = DateTime.UtcNow.AddDays(-3),
                        LinkToJob = "https://example.com/job/2"
                    },
   
                };

            _context.Job.AddRange(testJobs);
            _context.SaveChanges();

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<IEnumerable<Job>>(viewResult.ViewData.Model);
            Xunit.Assert.Equal(testJobs.Count, model.Count());
        }

        [TestMethod]
        [Fact]
        public async Task Edit_ReturnsViewWithJob()
        {
            var testJobs = new List<Job>
                {
                    new Job
                    {
                        Id = 1,
                        Title = "Senior Data Scientist",
                        Description = "Exciting opportunity for an experienced Data Scientist.",
                        Email = "jobs@example.com",
                        Company = "Tech Solutions Inc.",
                        CompanyLogo = "logo1.png",
                        PostedOn = DateTime.UtcNow.AddDays(-5),
                        LinkToJob = "https://example.com/job/1"
                    },
                    new Job
                    {
                        Id = 2,
                        Title = "Product Manager",
                        Description = "Join our team as a Product Manager and shape the future of our products.",
                        Email = "careers@example.com",
                        Company = "Innovate Tech",
                        CompanyLogo = "logo2.png",
                        PostedOn = DateTime.UtcNow.AddDays(-3),
                        LinkToJob = "https://example.com/job/2"
                    },

                };

            _context.Job.AddRange(testJobs);
            _context.SaveChanges();
            // Arrange
            var controller = new JobsController(_context);
            var jobId = 1; 

            // Act
            var result = await controller.Edit(jobId);

            // Assert
            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsType<Job>(viewResult.ViewData.Model);

            // Verify that the model is not null
            Xunit.Assert.NotNull(model);

            // Verify that the model has the correct ID
            Xunit.Assert.Equal(jobId, model.Id);
        }

        [TestMethod]
        [Fact]
        public async Task CreateUniversityUpdate_RedirectsToIndexOnSuccess()
        {
            // Arrange
            var controller = new UniversityUpdatesController(_context);
            var validUniversityUpdate = new UniversityUpdate
            {
               
                UpdateName = "Important Update",
                Description = "This is a test update.",
                Date = DateTime.UtcNow,
                Image = "path/to/image.jpg"
            };

            // Act
            var result = await controller.Create(validUniversityUpdate);

            // Assert
            var redirectToActionResult = Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.Equal("Index", redirectToActionResult.ActionName);
        }
        [TestMethod]
        [Fact]
        public async Task DeleteConfirmed_RemovesUniversityUpdateAndRedirectsToIndex()
        {
            // Arrange
            var controller = new UniversityUpdatesController(_context);
            var universityUpdateIdToDelete = 1;
            var universityUpdateToDelete = new UniversityUpdate
            {
           
                UpdateId = universityUpdateIdToDelete,
                UpdateName = "Update to Delete",
                Description = "This update should be deleted.",
                Date = DateTime.UtcNow,
                Image = "path/to/delete-image.jpg"
            };

            _context.UniversityUpdate.Add(universityUpdateToDelete);
            await _context.SaveChangesAsync();

            // Act
            var result = await controller.DeleteConfirmed(universityUpdateIdToDelete);

            // Assert
            var redirectToActionResult = Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.Equal("Index", redirectToActionResult.ActionName);

            var deletedUniversityUpdate = await _context.UniversityUpdate.FindAsync(universityUpdateIdToDelete);
            Xunit.Assert.Null(deletedUniversityUpdate); // Ensure the university update is deleted
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();

        }

    }




   
}