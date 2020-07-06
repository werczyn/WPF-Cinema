using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    /// <summary>
    /// directo who inherits from the person
    /// </summary>
    [Table("Director")]
    public class Director : Person
    {
        [NotMapped]
        private int _numberOfDirected = 0;

        /// <summary>
        /// Number of directed movies by this director
        /// </summary>
        [Display(Name = "Number of directed films")]
        public int NumberOfDirectedFilms { get => _numberOfDirected; }

        [NotMapped]
        private ICollection<Movie> _movies = new List<Movie>();

        /// <summary>
        /// List of directed movies
        /// </summary>
        public ICollection<Movie> Movies { 
            get => _movies; 
            set { 
                _movies = value;
                _numberOfDirected = _movies.Count;
            }
        }

        /// <summary>
        /// avarage user ratings
        /// </summary>
        [Display(Name = "Average users rating")]
        public double AverageUsersRating { get; set; }
    }
}