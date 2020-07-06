using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    public class CinemaHall
    {
        /// <summary>
        /// Cinema hall ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCinemaHall { get; set; }
        /// <summary>
        /// Name of cinema hall
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of seats in cinema hall
        /// </summary>
        [Display(Name = "Number of seats")]
        public int NumberOfSeats { get => _numberOfSeats; }

        [NotMapped]
        private int _numberOfSeats = 0;

        /// <summary>
        /// Representing in which cinema the cinema hall is located
        /// </summary>
        [ForeignKey("IdCinema")]
        public Cinema Cinema { get; set; }
        public int IdCinema { get; set; }

        /// <summary>
        /// List of seats in cinema hall
        /// </summary>
        public ICollection<Seat> Seats { get => _seats;
            set {
                _seats = value;
                _numberOfSeats = _seats.Count;
            }
        }
        [NotMapped]
        private ICollection<Seat> _seats = new List<Seat>();

        /// <summary>
        /// List of screenings in cinemahall
        /// </summary>
        public ICollection<Screening> Screenings { get; set; }

    }
}