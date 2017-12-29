using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using Newtonsoft.Json;

namespace MovieStar.Web.Models
{
    public interface IFilm
    {
        int Id { get; set; }
        string Title { get; set; }
    }

    //public class Film : IFilm
    //{
    //    //public int Id { get; set; }
    //    //public string Title { get; set; }
    //}

    public class MovieViewModel : IFilm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }

    public class SerialViewModel : IFilm
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}