using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Repositories;
using ApplicationCore.Contracts.Services;

namespace Movieshop.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
          
        }


        [HttpGet]
        [Route("")]
        // http://localhost:73434/api/movies?pagesize=30&page=2&title=ave
        public  IActionResult GetMoviesByPagination([FromQuery] int pageSize = 30, [FromQuery] int page = 1, string title = "")
        {
            var movies =  _movieService.GetMoviesByPagination(pageSize, page, title);
            if (movies == null || movies.Count == 0)
            {
                return NotFound($"no movies found for your search term {title}");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("toprevenue")]
        public  IActionResult GetTopRevenueMovies()
        {
            var movies =  _movieService.GetTop30GrossingMovies();

            if (!movies.Any())
            {
                return NotFound();
            }

            return Ok(movies);
        }
        [HttpGet]
        [Route("{id:int}")]
        public  IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieDetails(id);

            if (movie == null)
                return NotFound();
            return Ok(movie);
        }
        [HttpGet]
        [Route("toprated")]
        public  IActionResult GetAllMovies()
        {
            var movies =  _movieService.GetTop30GRatedMovies();

            if (!movies.Any() || movies.Count == 0)
            {
                return NotFound();
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("genre/{id:int}")]
        public  IActionResult GetMovieByGenreId(int id)
        {
            var genreMovies =  _movieService.MoviesSameGenre(id);

            if (!genreMovies.Any())
            {
                return NotFound();
            }
            return Ok(genreMovies);
        }
    }
}
