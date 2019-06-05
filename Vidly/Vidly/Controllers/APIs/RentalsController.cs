using System;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using Vidly.View_Models;

namespace Vidly.Controllers.APIs
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //api/Rentals
        [HttpPost]
        public IHttpActionResult NewRental( NewRentalViewModel newRenatl)
        {
            var customer = _context.Customers.Single(c => c.Id == newRenatl.CustomerId);

            var movies = _context.Movies.Where(m => newRenatl.MoviesIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is not available.");
                                                   
                movie.NumberInStock--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentDate = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    

    }
}
