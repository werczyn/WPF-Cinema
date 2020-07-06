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
    /// cinema class
    /// </summary>
    [Table("Cinema")]
    public partial class Cinema
    {
        /// <summary>
        /// Cinema ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCinema { get; set; }

        /// <summary>
        /// Name of cinema
        /// </summary>
        [Required, MaxLength(255), Display(Name = "Cinema Name")]
        public string CinemaName { get; set; } = "Polskie Kino";

        /// <summary>
        /// city ​​where the cinema is located
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street where the cinema is located
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// apartment number where the cinema is located
        /// </summary>
        [Display(Name = "Apartment Number")]
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// cinema phone number
        /// </summary>
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// list of cinema halls
        /// </summary>
        public ICollection<CinemaHall> CinemaHalls { get; set; }

    }
}
