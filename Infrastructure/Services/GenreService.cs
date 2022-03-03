using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        public GenreService(IGenreRepository _gen)
        {
            genreRepository = _gen;
        }
        public IEnumerable<GenreModel> GetAllGenres()
        {
            var data = genreRepository.GetAll();
            if (data != null)
            {
                List<GenreModel> model = new List<GenreModel>();
                foreach (var item in data)
                {
                    GenreModel m = new GenreModel();
                    m.Id = item.Id;
                    m.Name = item.Name;
                    model.Add(m);
                }
                return model;
            }
            return null;
        }

        public int InsertGenre(GenreModel model)
        {

            Genre g = new Genre();

            g.Name = model.Name;
            return genreRepository.Insert(g);

        }
        public int DeleteGenre(int id)
        {
            return genreRepository.Delete(id);
        }

        public int UpdateGenre(GenreModel model)
        {
            Genre g = new Genre() { Id = model.Id, Name = model.Name };
            return genreRepository.Update(g);
        }
    }
}
