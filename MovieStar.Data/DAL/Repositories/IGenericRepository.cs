using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStar.Data.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Add(IEnumerable<T> entities);
        T Delete(T entity);
        IEnumerable<T> Delete(IEnumerable<T> entities);
        T Update(T entity);
    }
}
