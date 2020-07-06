using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    /// <summary>
    /// abstract Person class
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Person identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }

        /// <summary>
        /// First name of person
        /// </summary>
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of person
        /// </summary>
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}