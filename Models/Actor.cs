using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    /// <summary>
    /// the actor inherits from the person
    /// </summary>
    [Table("Actor")]
    public class Actor : Person, IActing
    {
        /// <summary>
        /// average rating from users
        /// </summary>
        [Display(Name = "Average rating")]
        public double AverageRating { get; set; }

        [NotMapped]
        private int _numberOdActed = 0;

        /// <summary>
        /// number of movies he played in
        /// </summary>
        [Display(Name = "Noumber of acted")]
        public int NoumberOfActed { get => _numberOdActed; }

        /// <summary>
        /// list of movies he played in
        /// </summary>
        [NotMapped]
        private ICollection<Movie> _movies = new List<Movie>();
        public ICollection<Movie> Movies { 
            get => _movies;
            set { 
                _movies = value;
                _numberOdActed = _movies.Count;
            }
        }

        public void AddActedMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        public bool RemoveActedMovie(Movie movie)
        {
            return Movies.Remove(movie);
        }
    }
}
