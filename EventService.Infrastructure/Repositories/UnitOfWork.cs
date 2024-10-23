using EventServices.Application.IRepositories;
using EventServices.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _db;

        public IProgramRepository ProgramRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public ISessionRepository SessionRepository { get; private set; }

        public UnitOfWork(IApplicationDbContext db)
        {
            _db = db;
            
            EventRepository = new EventRepository(_db);
            SessionRepository = new SessionRepository(_db); 
            ProgramRepository = new ProgramRepository(_db);

        }


        public async Task<int> CompleteAsync()
            => await _db.SaveChangesAsync();//special method


    }

}
