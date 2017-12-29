using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using MovieStar.Data.DAL;
using MovieStar.Data.DAL.Services;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Tests
{
    /// <summary>
    /// Summary description for SearchRobotTests
    /// </summary>
    [TestClass]
    public class SearchRobotTests
    {
        public SearchRobotTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SearchRobot_Search()
        {
            // Arrange
            var data = GetTestData();
            var context = GetMockDataContext(data);
            var genre = new Genre { Id = 1, Name = "Drama" };
            // Act
            ISearchRobot robot = new SearchRobot(new MovieService(context), new EmailMessenger());
            var results = robot.Search(new SearchParameters { Genre = genre, YearStart = 1998, YearEnd = 2012 });

            // Assert
            results.Should().NotBeNull();
            results.Count().Should().Be(2);
        }

        [TestMethod]
        public void SearchRobot_Internal()
        {
            var data = GetTestData();
            var context = GetMockDataContext(data);
            var robot = new SearchRobot(new MovieService(context), new EmailMessenger());

            var result = robot.Completed();

            result.Should().Be(true);
        }

        private IQueryable<Movie> GetTestData()
        {
            var genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Drama" },
                new Genre { Id = 2, Name = "Romance" },
                new Genre { Id = 3, Name = "Science Fiction" },
                new Genre { Id = 4, Name = "Action" },
                new Genre { Id = 5, Name = "Superhero" }
            };
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Captain America: Civil War", Year = 2016, Genres = new HashSet<Genre> { genres[3], genres[4] } },
                new Movie { Id = 2, Title = "Casablanca", Year = 1942, Genres = new HashSet<Genre> { genres[0], genres[2]} },
                new Movie { Id = 3, Title = "Great Expectations", Year = 1946, Genres = new HashSet<Genre> { genres[0] } },
                new Movie { Id = 4, Title = "Great Expectations", Year = 1998, Genres = new HashSet<Genre> { genres[0] } },
                new Movie { Id = 5, Title = "Great Expectations", Year = 2012, Genres = new HashSet<Genre> { genres[0] } }
            };
            return movies.AsQueryable();
        }

        private DataContext GetMockDataContext(IQueryable<Movie> data)
        {
            var mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>("fake connection string");
            mockContext.Setup(m => m.Movies).Returns(mockSet.Object);

            return mockContext.Object;
        }
    }
}
