using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesCatalog.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(Expression<Func<T, bool>> where);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int count = 0);

        void Detach(T entity);
    }

    internal abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        protected DbContext db;
        protected readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DbContext DbContext
        {
            get { return db ?? (db = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Detach(T entity)
        {
            db.Entry(entity).State = EntityState.Detached;
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Remove(Expression<Func<T, bool>> where)
        {
            dbSet.RemoveRange(dbSet.Where(where));
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int count = 0)
        {

            return count == 0 ? await dbSet.ToListAsync() : await dbSet.Take(count).ToListAsync();
        }

        #endregion

    }
}
