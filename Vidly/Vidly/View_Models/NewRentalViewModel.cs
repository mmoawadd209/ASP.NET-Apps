using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.View_Models
{
    public class NewRentalViewModel
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}