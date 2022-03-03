using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        
        List<Movie> Get30HighestGrossingMovies();
        List<Movie> Get30HighestRatedMovies();
        decimal GetMovieRating(int id);
        List<Movie> GetMoviesSameGenre(int id);

        PagedResultSet<Movie> GetMoviesByTitle(int pageSize = 30, int page = 1, string title = "");
       


    }
}
