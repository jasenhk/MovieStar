using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStar.Data.Models.Entities;

namespace MovieStar.Data.DAL
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(string connectionString)
            : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
            Database.SetInitializer<DataContext>(null);
        }

        public virtual IDbSet<Movie> Movies { get; set; }
        public virtual IDbSet<Genre> Genres { get; set; }

        public void ExecuteSqlCommand(string cmd, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(cmd, parameters);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureMovieGenreRelation(DbModelBuilder modelBuilder)
        {

        }
    }
}
