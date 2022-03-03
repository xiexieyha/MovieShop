using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>,IGenreRepository
    {
        //insert/delete/update/getall/getbycondition
        public GenreRepository(MovieShopDbContext _con) : base(_con)
        {
        }
    }
}
