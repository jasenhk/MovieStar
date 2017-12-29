using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.DAL;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL.Services
{
    public class SearchRobot : ISearchRobot
    {
        private IMovieService movieService;
        private IMessenger messenger;

        public SearchRobot(IMovieService movieService, IMessenger messenger)
        {
            this.movieService = movieService;
            this.messenger = messenger;
        }

        public bool Notify(Message message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> Search(SearchParameters parameters)
        {
            var movies = movieService.GetMoviesByGenre(parameters.Genre.Name);
            return movies;
        }
        
        internal bool Completed()
        {
            return true;
        }
    }
}
