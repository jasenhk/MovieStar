using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.DAL;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL.Services
{
    public class MovieService : IMovieService
    {
        private DataContext dbContext;
        public MovieService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Movie GetMovieById(int id)
        {
            var movie = dbContext.Movies.FirstOrDefault(m => m.Id == id);
            return movie;
        }

        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            var movies = dbContext.Movies.Where(m => m.Title == title);
            return movies;
        }

        public IEnumerable<Genre> GetMovieGenre(int movieId)
        {
            var movie = dbContext.Movies.FirstOrDefault(m => m.Id == movieId);
            return movie.Genres.ToList();
        }

        public IEnumerable<Movie> GetMoviesByGenre(string genreName)
        {
            throw new NotImplementedException();
        }
    }

    public class MovieServiceStub : IMovieService
    {
        public Movie GetMovieById(int id)
        {
            return new Models.Entities.Movie { Id = 1, Title = "The Matrix", Year = 1999 };
        }

        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetMovieGenre(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(string genreName)
        {
            throw new NotImplementedException();
        }
    }
}
