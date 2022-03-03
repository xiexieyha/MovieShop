using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _db;
        public BaseRepository(MovieShopDbContext _con)
        {
             _db = _con;
        }
        public int Delete(int id)

        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                return 1;
            }
            return 0;

        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T,bool>> filter)
        {
            return _db.Set<T>().Where(filter);
        }

        public T GetByCondition(Expression<Predicate<T>> filter)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
           return _db.Set<T>().Find(id);
            
        }

        public int Insert(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return 1;
        }

        public int Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return 1;
        }

       
    }
}
