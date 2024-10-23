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
        public ISliderRepository SliderRepository { get; private set; }

        public UnitOfWork(IApplicationDbContext db, IProgramRepository programRepository, IEventRepository eventRepository, ISessionRepository sessionRepository, ISliderRepository sliderRepository)
        {
            _db = db;
            ProgramRepository = programRepository;
            EventRepository = eventRepository;
            SessionRepository = sessionRepository;
            SliderRepository = sliderRepository;
        }


        public async Task<int> CompleteAsync()
            => await _db.SaveChangesAsync();//special method


    }

}
