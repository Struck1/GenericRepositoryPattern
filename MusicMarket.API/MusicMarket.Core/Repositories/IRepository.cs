using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> SingleOrDefalutAsync(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Find(Expression<Func<T, bool>> pradicate);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
