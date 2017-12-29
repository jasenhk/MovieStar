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
    [TestClass]
    public class MovieServiceTests
    {
        [TestMethod]
        public void MovieStarService_GetById()
        {
            // Arrange
            var data = GetTestData();

            var mockContext = GetMockDataContext(data);

            // Act
            var service = new MovieService(mockContext);
            var movie = service.GetMovieById(1);

            // Assert
            movie.Should().NotBeNull();
            movie.Title.Should().Be("Captain America: Civil War");
            movie.Year.Should().Be(2016);
        }

        [TestMethod]
        public void MovieStarService_GetByTitle()
        {
            // Arrange
            var data = GetTestData();
            var mockContext = GetMockDataContext(data);

            // Act
            IMovieService service = new MovieService(mockContext);
            var movies = service.GetMovieByTitle("Great Expectations");

            // Assert
            movies.Should().NotBeNull();
            movies.Count().Should().Be(3);
            movies.First(m => m.Id == 3).Year.Should().Be(1946);
            movies.First(m => m.Id == 4).Year.Should().Be(1998);
            movies.First(m => m.Id == 5).Year.Should().Be(2012);
        }

        [TestMethod]
        public void MovieStarService_GetMovieGenre()
        {
            // Arrange
            var data = GetTestData();
            var context = GetMockDataContext(data);

            // Act
            IMovieService service = new MovieService(context);
            var genres = service.GetMovieGenre(5);


            // Assert
            Assert.AreEqual(genres.First().Name, "Drama");
        }

        [TestMethod]
        public void TestBasicLock()
        {
            var result = TestLock(null);
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

        private bool TestLock(string count)
        {
            return Int32.Parse(count) > 0;
        }
    }
}
