using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;

        }

        public async Task AddAsync(T entity)
        {

            await Context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> pradicate)
        {
            return Context.Set<T>().Where(pradicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public async Task<T> SingleOrDefalutAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}
