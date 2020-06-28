using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task.Data;

namespace Task.Repositories.RepositorieBase
{


    public class RepositorieBase<T> : IRepositorieBase<T> where T : class
    {
        protected readonly ApplicationDbContext db;

        public RepositorieBase(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate,  string includeProperties="" )
        {
            IQueryable<T> query = db.Set<T>();
            if (!string.IsNullOrEmpty( includeProperties))
            {
                foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await db.Set<T>().Where(predicate).ToListAsync();
        }

        public void Remove(T entity)
        {
            db.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            db.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;

        }


    }
}