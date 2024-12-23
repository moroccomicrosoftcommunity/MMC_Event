﻿using EventServices.Application.IRepositories;
using EventServices.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventServices.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<T> _db;

        public Repository(IApplicationDbContext db)
        {
            _context = db;
            _db = _context.Set<T>();
        }
        public async Task<T?> GetAsync<TKey>(TKey id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db;

            foreach (var item in includes)
                query = query.Include(item);

            return await query.FirstOrDefaultAsync(e => EF.Property<TKey>(e, "Id").Equals(id));
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db;
            // Apply the filter if provided
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var item in includes)
                query = query.Include(item);

            return await query.ToListAsync();
        }
        public async Task<bool> PostAsync(T entity)
        {
            await _db.AddAsync(entity);
            return true;
        }
        public async Task<T?> PutAsync<TKey>(TKey id, T entity)
        {
            var data = await GetAsync(id);
            if (data is null) return default;

            _db.Entry(data).CurrentValues.SetValues(entity);
            return data;
        }
        public async Task<bool> RemoveAsync<TKey>(TKey id)
        {
            var data = await GetAsync(id);
            if (data is not null)
            {
                _db.Remove(data);
                return true;
            }
            return false;
        }

      
    }
}
