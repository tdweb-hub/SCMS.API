using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCMS.API.Domain.Repositories
{
    interface IDataRepository<T>
    {
        void Delete(T entity);
        void Delete(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetById(object id);
        IEnumerable<T> GetWithRawSql(string query, params object[] parameters);
        int Insert(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
    }
}
