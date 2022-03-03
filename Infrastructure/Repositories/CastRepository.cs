using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CastRepository:BaseRepository<Cast>,ICastRepository
    {
        MovieShopDbContext _db;
        public CastRepository(MovieShopDbContext dbContext):base(dbContext)
        {
            _db = dbContext;
        }

        public Cast GetCast(int id)
        {
            return _db.Casts.Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}
