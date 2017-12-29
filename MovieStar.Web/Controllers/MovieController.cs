using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStar.Data.DAL.Services;
using MovieStar.Data.Models.Entities;
using MovieStar.Web.Models;
using System.Net;

namespace MovieStar.Web.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movie = movieService.GetMovieById(1);
            return View(movie);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var movies = new List<MovieViewModel>()
            {
                new MovieViewModel { Id = 1, Title = "Matrix", Year = 1999 },
                new MovieViewModel { Id = 2, Title = "Arrival", Year = 2016 }
            };
            var movie = new MovieViewModel { Id = 1, Title = "Matrix", Year = 1999 };
            return View(movie);
        }

        [HttpPost]
        public ActionResult Update(int id, MovieViewModel model)
        {
            if (true)
            {
                ViewBag.Message = "Sorry";
                return View(model);
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult FanService()
        {
            var clues = new List<Clue>()
            {
                new Clue() { Id = 1, Name = "Deathstar" },
                new Clue() { Id = 2, Name = "Pink Lightsaber" }
            };
            var easterEgg = new EasterEgg()
            {
                Fan = new Fan() { Name = "Chewy" },
                Clues = clues
            };

            return View(easterEgg);
        }

        [HttpPost]
        public ActionResult FanService(EasterEgg egg)
        {
            return RedirectToAction("FanService");
        }

        [HttpGet]
        public ActionResult FanPage()
        {
            var model = new ExtraneousViewModel
            {
                Date = new DateTime(),
                EasterEgg = new EasterEgg
                {
                    Fan = new Fan { Name = "Jar-Jar" },
                    Clues = new List<Clue>
                    {
                        new Clue { Id = 1, Name = "Lens flair" },
                        new Clue { Id = 2, Name = "McGuffin" }
                    }
                }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Foo(string json)
        {
            var obj = json;
            return RedirectToAction("Index");
        }
    }

    public class ExtraneousViewModel
    {
        public DateTime Date { get; set; }
        public EasterEgg EasterEgg { get; set; }
    }

    public class Fan
    {
        public string Name { get; set; }
    }

    public class Clue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EasterEgg
    {
        public Fan Fan { get; set; }
        public List<Clue> Clues { get; set; }
    }

    public class Foo
    {
        public int Id { get; set; }
        public List<string> Bars { get; set; }
    }
}