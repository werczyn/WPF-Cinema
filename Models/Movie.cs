using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    /// <summary>
    /// Movie class
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Movie identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovie { get; set; }

        /// <summary>
        /// Unique title of movie
        /// </summary>
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Title { get; set; }

        /// <summary>
        /// movie description length < 500
        /// </summary>
        [Display(Name = "Movie description")]
        [StringLength(500)]
        public string MovieDescription { get; set; }

        /// <summary>
        /// Avarage users rating
        /// </summary>
        [Display(Name = "Average users rating")]
        public double AverageUsersRating { get; set; }

        /// <summary>
        /// Movie length
        /// </summary>
        [Display(Name = "Movie length")]
        public double MovieLength { get; set; }

        /// <summary>
        /// Language of movie
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// proposed minimum age for movie
        /// </summary>
        [Display(Name = "Proposed minimum age")]
        public int ProposedMinimumAge { get; set; }

        /// <summary>
        /// List of movie generes
        /// </summary>
        public ICollection<MovieGenre> MovieGenres { get; set; }

        /// <summary>
        /// List of actors in movie
        /// </summary>
        public ICollection<Actor> Actors { get; set; }

        /// <summary>
        /// Director of movie
        /// </summary>
        [ForeignKey("IdDirector")]
        public Director Director { get; set; }
        public int IdDirector { get; set; }

        /// <summary>
        /// List of screenings
        /// </summary>
        public ICollection<Screening> Screenings { get; set; }



    }
}