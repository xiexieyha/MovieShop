using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        List<MovieCardResponseModel> GetTop30GrossingMovies();
        List<MovieCardResponseModel> GetTop30GRatedMovies();
        MovieDetailsResponseModel GetMovieDetails(int id);
        List<MovieCardResponseModel> MoviesSameGenre(int id);
        PagedResultSet<MovieCardResponseModel> GetMoviesByPagination(int pageSize, int page, string title);
       

    }
}
