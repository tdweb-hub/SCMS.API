using SCMS.API.Domain.Repositories;
using SCMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCMS.API.Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        internal SCMSEntities _context;
        internal DbSet<T> _dbSet;

        public DataRepository(SCMSEntities _context)
        {
            this._context = _context;
            this._dbSet = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            T _entityToDelete = _dbSet.Find(id);
            Delete(_entityToDelete);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> _query = _dbSet;
            if (filter != null)
            {
                _query = _query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var _includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    _query = _query.Include(_includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(_query).ToList();
            }
            return _query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
