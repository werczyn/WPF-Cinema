using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    public class MovieGenre
    {
        /// <summary>
        /// Movie genere identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovieGenre { get; set; }

        /// <summary>
        /// Name of movie genere
        /// </summary>
        [Display(Name = "Name of Genere")]
        public string NameOfGenere { get; set; }

        /// <summary>
        /// List of movies 
        /// </summary>
        public ICollection<Movie> Movies { get; set; }

    }
}