using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    /// <summary>
    /// client in cinema who inherits from the person
    /// </summary>
    [Table("Client")]
    public class Client : Person
    {
        /// <summary>
        /// email address of client
        /// </summary>
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// phone number to client
        /// </summary>
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// list of reservations
        /// </summary>
        public ICollection<Reservation> Reservations { get; set; }

    }
}