using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace MovieStar.Data
{
    /// <summary>
    /// This is just a stub to verify Dispose()
    /// </summary>
    public class MovieStarDbContext : IDbContext, IDisposable
    {
        private ILog log;
        private readonly Guid Guid;

        public IQueryable<Movie> Movies { get; set; }
        
        public MovieStarDbContext(string connectionString, ILog log)
        {
            this.Guid = Guid.NewGuid();
            this.log = log;

            this.Movies = (new List<Movie>()
            {
                new Movie { Id = 1, Title = "Star Battles: Episode IX -- Return of the Porg", ReleaseDate = null
            }
            }).AsQueryable();
        }

        public void Dispose()
        {
            log.InfoFormat("Dispose {0}", Guid);
        }
    }
}