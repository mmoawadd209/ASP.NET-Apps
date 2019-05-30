
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.View_Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
                return View(movies);        
        }



        // Get : Movies/Create
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new MovieViewModel()
            {               
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }



        // Get : Movies/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            var viewModel = new MovieViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }

        

        // Post : Movies/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;  
            }
                           
            _context.SaveChanges();
                                    
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
    }
}