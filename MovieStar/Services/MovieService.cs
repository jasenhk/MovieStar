using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStar.Data;

namespace MovieStar.Services
{
    public class MovieService : IMovieService
    {
        private readonly IDbContext db;

        public MovieService(IDbContext db)
        {
            this.db = db;
        }

        public Movie GetMovie(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);

            return movie;
        }
    }
}