using Dramonkiller.CareHomeApp.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.Domain.Infrastructure
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();

        T FindById(int id);

        Task<T> FindAsync(int id);

        int Count();

        Task<int> CountAsync();

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);
    }
}
