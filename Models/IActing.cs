using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    /// <summary>
    /// Interface made for multi-inherits acting director
    /// </summary>
    public interface IActing
    {
        void AddActedMovie(Movie movie);
        bool RemoveActedMovie(Movie movie);
    }
}
