using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    /// <summary>
    /// Director who can act; multi-inheritance
    /// </summary>
    [Table("ActingDiorector")]
    class ActingDirector : Director, IActing
    {
        /// <summary>
        /// List of acted Movies
        /// </summary>
        public List<Movie> ActedMovies { get; set; } = new List<Movie>();
        
        /// <summary>
        /// Method to add acted movie
        /// </summary>
        /// <param name="movie"></param>
        public void AddActedMovie(Movie movie)
        {
            ActedMovies.Add(movie);
        }

        /// <summary>
        /// Method to remove acted movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns> true value if deleting is sucessfull</returns>
        public bool RemoveActedMovie(Movie movie)
        {
            return ActedMovies.Remove(movie);
        }

    }
}
