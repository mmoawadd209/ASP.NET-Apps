using System;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}