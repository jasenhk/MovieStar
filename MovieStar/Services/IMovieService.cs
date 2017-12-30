using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data;

namespace MovieStar.Services
{
    public interface IMovieService
    {
        Movie GetMovie(int id);
    }
}
