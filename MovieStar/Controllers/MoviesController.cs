﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using MovieStar.Data;
using MovieStar.Services;

namespace MovieStar.Controllers
{
    public class MoviesController : Controller
    {
        private Guid Guid;
        private ILog log = LogManager.GetLogger("MoviesApiController");
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.Guid = Guid.NewGuid();
            this.movieService = movieService;
        }

        // GET: Movies
        public ActionResult Index(int id)
        {
            log.InfoFormat("(MVC) GET movie {0}, GUID {1}", id, this.Guid);

            var movie = movieService.GetMovie(id);

            return Json(movie, JsonRequestBehavior.AllowGet);
        }
    }
}