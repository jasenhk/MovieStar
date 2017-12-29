using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL.Services
{
    public interface IMovieService
    {
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetMovieByTitle(string title);
        IEnumerable<Genre> GetMovieGenre(int movieId);

        IEnumerable<Movie> GetMoviesByGenre(string genreName);
    }
}
