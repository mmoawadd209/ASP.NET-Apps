using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: api/Movies
        public IHttpActionResult GetMovies(string query = null)
        {

            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                . Where(m => m.NumberInStock > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));            
            
            var moviesDto = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDto);
        }


        // GET: api/Movies/5
        [ResponseType(typeof(MovieDto))]
        public IHttpActionResult GetMovie(int id)
        {
            var  movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return Ok(movieDto);
        }



        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        [Authorize(Roles =RoleName.CanManageMovies)]
        public IHttpActionResult PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)           
                return BadRequest(ModelState);
      
            var movieInDb = _context.Movies.Find(id);

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }



        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        [Authorize(Roles =RoleName.CanManageMovies)]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return CreatedAtRoute("DefaultApi", new { id = movieDto.Id }, movieDto);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        [Authorize(Roles =RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)            
                return NotFound();
            

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}