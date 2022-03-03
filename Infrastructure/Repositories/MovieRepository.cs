using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        MovieShopDbContext _dbContext;
        public MovieRepository(MovieShopDbContext context):base(context)
        {
            _dbContext= context;
        }
        public List<Movie> Get30HighestGrossingMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();

            return movies;
        }

        public List<Movie> Get30HighestRatedMovies()
        {
            var topRatedMovies =  _dbContext.Reviews.Include(r => r.Movie).GroupBy(r => new { r.MovieId, r.Movie.PosterUrl, r.Movie.Title })
                .OrderByDescending(m => m.Average(r => r.Rating)).Select(m => new Movie
                {
                    Id = m.Key.MovieId,
                    PosterUrl = m.Key.PosterUrl,
                    Title = m.Key.Title,
                }).Take(30).ToList();

            return topRatedMovies;
        }

        public decimal GetMovieRating(int id)
        {
            var movieRating =  _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty().Average(r => r == null ? 0 : r.Rating);
            return movieRating;
        }

        public PagedResultSet<Movie> GetMoviesByTitle(int pageSize = 30, int page = 1, string title = "")
        {
            var movies =  _dbContext.Movies.Where(m => m.Title.Contains(title)).OrderBy(m => m.Title).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // total movies  for that condition 
            // select count(*) from Movies where title like '%ave%'

            var totalMoviesCount = _dbContext.Movies.Where(m => m.Title.Contains(title)).Count();

            var pagedMovies = new PagedResultSet<Movie>(movies, page, pageSize, totalMoviesCount);

            return pagedMovies;
        }

        public List<Movie> GetMoviesSameGenre(int id)
        {
            var genreMovies =  _dbContext.MovieGenres.Include(m => m.Movie).Where(m => m.GenreId == id).Select(m => m.Movie).ToList();
            return genreMovies;
        }
    }
}
