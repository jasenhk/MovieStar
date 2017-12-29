using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStar.Data.Models.Entities
{
    [Table("Movie", Schema = "dbo")]
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<Genre>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public virtual ISet<Genre> Genres { get; set; }
    }
}
