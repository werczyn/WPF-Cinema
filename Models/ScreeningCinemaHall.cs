using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    /// <summary>
    /// helper class for linq query
    /// </summary>
    class ScreeningCinemaHall
    {
        /// <summary>
        /// Cinema hall ID
        /// </summary>
        public int IdCinemaHall { get; set; }
        /// <summary>
        /// Screening ID
        /// </summary>
        public int IdScreening { get; set; }

        /// <summary>
        /// Date of projection
        /// </summary>
        [Display(Name = "Date of Projection")]
        public DateTime DateOfProjection { get; set; }

        /// <summary>
        /// Name of cinema hall
        /// </summary>
        [Display(Name = "Cinema hall name")]
        public string CinemaHallName { get; set; }

        /// <summary>
        /// Movie
        /// </summary>
        public Movie Movie { get; set; }
    }
}
