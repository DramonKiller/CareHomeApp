using Dramonkiller.CareHomeApp.Domain.Entities;
using Dramonkiller.CareHomeApp.Domain.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.DataAccess.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public EntityBaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        
        public virtual IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public virtual T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual Task<T> FindAsync(int id)
        {
            return dbSet.FindAsync(id);
        }

        public virtual int Count()
        {
            return dbSet.Count();
        }

        public Task<int> CountAsync()
        {
            return dbSet.CountAsync();
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> entities = context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

    }
}
