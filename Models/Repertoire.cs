using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektMAS.Models
{
    public class Repertoire
    {
        /// <summary>
        /// Repertoire Identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRepertoire { get; set; }

        /// <summary>
        /// Datetime since when movie is in repertoire
        /// </summary>
        [Display(Name = "Since when")]
        public DateTime SinceWhen { get; set; }

        /// <summary>
        /// Datetime to when movie is in repertoire
        /// </summary>
        [Display(Name = "To when")]
        public DateTime ToWhen { get; set; }

        /// <summary>
        /// Bool value represents is movie still played
        /// </summary>
        [NotMapped]
        public bool IsPlayed {
            get
            {
                if (DateTime.Now > SinceWhen && DateTime.Now < ToWhen)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Static method for checing if is played
        /// </summary>
        /// <param name="sinceWhen"></param>
        /// <param name="toWhen"></param>
        /// <returns></returns>
        public static bool CheckIsPlayed(DateTime sinceWhen, DateTime toWhen)
        {
            if (DateTime.Now > sinceWhen && DateTime.Now < toWhen)
            {
                return true;
            }
            return false;
        }

    }
}