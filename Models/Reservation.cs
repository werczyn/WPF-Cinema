using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    public class Reservation
    {
        /// <summary>
        /// Reservation identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReservation { get; set; }

        /// <summary>
        /// Expiriation date of reservation
        /// </summary>
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Reservation of client
        /// </summary>
        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        
        public Client Client { get; set; }

        /// <summary>
        /// On which screening is reservation
        /// </summary>
        public int IdScreening { get; set; }
        [ForeignKey("IdScreening")]
        public Screening Screening { get; set; }

        /// <summary>
        /// On which seat is reservation
        /// </summary>
        public int IdSeat { get; set; }
        [ForeignKey("IdSeat")]
        public Seat Seat { get; set; }


    }
}