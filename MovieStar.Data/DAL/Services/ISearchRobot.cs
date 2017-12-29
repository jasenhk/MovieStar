using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL.Services
{
    public interface ISearchRobot
    {
        IEnumerable<Movie> Search(SearchParameters parameters);
        bool Notify(Message message);
    }
}
