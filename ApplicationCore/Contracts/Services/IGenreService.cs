using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        IEnumerable<GenreModel> GetAllGenres();
        int InsertGenre(GenreModel model);
        int DeleteGenre(int id);
        int UpdateGenre(GenreModel model);
    }
}
