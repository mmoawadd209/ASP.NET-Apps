
using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.View_Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}