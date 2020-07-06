using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    /// <summary>
    /// class reprezenting the database
    /// </summary>
    public partial class CinemaDbContext : DbContext
    {
        /// <summary>
        /// database settings and disabling lazy loading
        /// </summary>
        public CinemaDbContext() : base("name=CinemaDb")
        {
            //disabling lazy loading
            this.Configuration.LazyLoadingEnabled = false;
        }

        //DbSets of models in database
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Repertoire> Repertoires { get; set; }


    }
}
