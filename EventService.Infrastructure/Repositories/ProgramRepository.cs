using EventServices.Application.IRepositories;
using EventServices.Domain.Entities;
using EventServices.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventServices.Infrastructure.Repositories
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {

        private readonly IApplicationDbContext _context;
        private readonly DbSet<Program> _db;

        public ProgramRepository(IApplicationDbContext db) : base(db)
        {
            _context = db;
            _db = _context.Set<Program>();
        }
        public async Task<IEnumerable<Program>> FindAllProgramOnly(params Expression<Func<Program, object>>[] includes)
        {
            IQueryable<Program> query = _db;

            foreach (var item in includes)
                query = query.Include(item);

            return await query.ToListAsync();
        }

    }
}
