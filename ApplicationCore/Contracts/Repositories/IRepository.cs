using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> filter);
        T GetById(int id);
        T GetByCondition(Expression<Predicate<T>> filter);
    }
}
