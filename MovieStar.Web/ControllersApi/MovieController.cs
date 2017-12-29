using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MovieStar.Web.Models;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieStar.Web.ControllersApi
{
    public class MovieController : ApiController
    {
        [Route("api/movies")]
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            List<IFilm> films = new List<IFilm>() { };

            return Ok<IEnumerable<IFilm>>(films);
        }

        [Route("api/movies/update")]
        [HttpPost]
        public IHttpActionResult Update(JArray films)
        {
            foreach(var item in films)
            {
                var year = item.SelectToken("Year");
            }

            return Ok();
        }
    }
}