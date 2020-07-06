using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    public class Screening
    {
        /// <summary>
        /// Screening identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdScreening { get; set; }

        /// <summary>
        /// Date of projection
        /// </summary>
        [Display(Name = "Date of projection")]
        public DateTime DateOfProjection { get; set; }
        
        /// <summary>
        /// Translation
        /// </summary>
        public string Translation { get; set; }

        /// <summary>
        /// List of reservations
        /// </summary>
        public ICollection<Reservation> Reservations { get; set; }

        /// <summary>
        /// Movie in screening
        /// </summary>
        [ForeignKey("IdMovie")]
        public Movie Movie { get; set; }
        public int IdMovie { get; set; }

        /// <summary>
        /// where screening will be displayed
        /// </summary>
        [ForeignKey("IdCinemaHall")]
        public CinemaHall CinemaHall { get; set; }
        public int IdCinemaHall { get; set; }
    }
}