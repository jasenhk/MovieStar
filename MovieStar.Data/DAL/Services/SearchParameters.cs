using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL.Services
{
    public class SearchParameters
    {
        public Genre Genre { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
    }
}
