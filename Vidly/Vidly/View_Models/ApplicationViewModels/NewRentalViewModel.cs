using System.Collections.Generic;

namespace Vidly.View_Models.ApplicationViewModels
{
    public class NewRentalViewModel
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}