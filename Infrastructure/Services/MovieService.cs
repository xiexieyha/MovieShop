using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
namespace Infrastructure.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public  MovieDetailsResponseModel GetMovieDetails(int id)
        {
            var movieDetails =  _movieRepository.GetById(id);
            var rating =  _movieRepository.GetMovieRating(id);

            var movieModel = new MovieDetailsResponseModel
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                Overview = movieDetails.Overview,
                Tagline = movieDetails.Tagline,
                Budget = movieDetails.Budget,
                Revenue = movieDetails.Revenue,
                ImdbUrl = movieDetails.ImdbUrl,
                TmdbUrl = movieDetails.TmdbUrl,
                ReleaseDate = movieDetails.ReleaseDate,
                RunTime = movieDetails.RunTime,
                Price = movieDetails.Price,
                Rating = rating,

            };

            foreach (var genre in movieDetails.GernesOfMovie)
            {
                movieModel.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name });
            }

            foreach (var trailer in movieDetails.Trailers)
            {
                movieModel.Trailers.Add(new TrailerResponseModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }

            foreach (var cast in movieDetails.MovieCast)
            {
                movieModel.Casts.Add(new CastResponseModel { Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath });
            }

            return movieModel;

        }
        public  PagedResultSet<MovieCardResponseModel> GetMoviesByPagination(int pageSize, int page, string title)
        {
            var pagedMovies =  _movieRepository.GetMoviesByTitle(pageSize, page, title);

            var pagedMovieCards = new List<MovieCardResponseModel>();

            pagedMovieCards.AddRange(pagedMovies.Data.Select(m => new MovieCardResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            }));

            return new PagedResultSet<MovieCardResponseModel>(pagedMovieCards, page, pageSize, pagedMovies.Count);

        }
        public  List<MovieCardResponseModel> GetTop30GRatedMovies()
        {
            var topRatedMovies =  _movieRepository.Get30HighestRatedMovies();

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in topRatedMovies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return movieCards;

        }
        public  List<MovieCardResponseModel> GetTop30GrossingMovies()
        {
            // we need to call the MovieRepository and get the data from Movies Table
            var movies =  _movieRepository.Get30HighestGrossingMovies();
            // map the data from movies (List<Movie>) to movieCards (List<MovieCardResponseModel>)

            var movieCards = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return movieCards;
        }

        public List<MovieCardResponseModel> MoviesSameGenre(int id)
        {
            var genreMovies = _movieRepository.GetMoviesSameGenre(id);

            var genreModel = new List<MovieCardResponseModel>();

            foreach (var movie in genreMovies)
            {
                genreModel.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return genreModel;
        }

    }
}
