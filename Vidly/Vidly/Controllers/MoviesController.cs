
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {


            var movies = GetAllMovies();
       
         
                return View(movies);
         
        }





        public IEnumerable<Movie> GetAllMovies()
        {
            var Movies = new List<Movie>
            {
                new Movie {Id = 0, Name = "sherek"},
                new Movie {Id = 1, Name = "Moana"},
                new Movie {Id = 2, Name = "Cars"},
            };
            return Movies;
        }
    }
}