using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using MovieStar.Data;
using MovieStar.Services;

namespace MovieStar.Controllers
{
    public class MoviesApiController : ApiController
    {
        private Guid Guid;
        private ILog log = LogManager.GetLogger("MoviesApiController");
        private readonly IMovieService movieService;

        public MoviesApiController(IMovieService movieService)
        {
            this.Guid = Guid.NewGuid();
            this.movieService = movieService;
        }

        [HttpGet]
        [Route("api/movies/{id}")]
        public IHttpActionResult GetMovie(int id)
        {
            log.InfoFormat("(API) GET movie {0}, GUID {1}", id, this.Guid);

            var movie = this.movieService.GetMovie(id);

            return Ok(movie);
        }
    }
}