using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    public class Seat
    {
        /// <summary>
        /// Seat ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSeat { get; set; }

        /// <summary>
        /// The row in which the seat is located
        /// </summary>
        [Display(Name = "Seat row")]
        public string SeatRow { get; set; }

        /// <summary>
        /// The number in which the seat is located
        /// </summary>
        [Display(Name = "Seat number")]
        public int SeatNumber { get; set; }

        /// <summary>
        /// State of seat
        /// </summary>
        [Display(Name = "Is free")]
        public bool IsSeatFree { get; set; }

        /// <summary>
        /// Cinema hall in which the seat is located
        /// </summary>
        [ForeignKey("IdCinemaHall")]
        public CinemaHall CinemaHall { get; set; }
        public int IdCinemaHall { get; set; }

    }
}