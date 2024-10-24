﻿using EventServices.Application.IRepositories;
using EventServices.Domain.Entities;
using EventServices.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventServices.Infrastructure.Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Session> _db;

        public SessionRepository(IApplicationDbContext db) : base(db)
        {
            _context = db;
            _db = _context.Set<Session>();
        }
        public async Task<IEnumerable<Session>> FindAllSession(params Expression<Func<Session, object>>[] includes)
        {
            IQueryable<Session> query = _db;
            foreach (var item in includes)
                query = query.Include(item);
            return query;

        }
        public async Task<IEnumerable<Session>> GetSessionByEventId(Guid Id, params Expression<Func<Session, object>>[] includes)
        {
            IQueryable<Session> query = _db;

            foreach (var item in includes)
                query = query.Include(item);

            return query.Where(e => e.EventId == Id);
        }
    }
}
