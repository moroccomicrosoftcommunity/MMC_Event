using EventServices.Application.Interfaces;

namespace EventServices.Application.Services
{
    public class UnitOfService : IUnitOfService
    {
        public IEventService EventService { get; private set; }
        public ISessionService SessionService { get; private set; }
        public IProgramService ProgramService { get; private set; }
        public IBlobService BlobService { get; private set; }
        public UnitOfService(IEventService eventService, ISessionService sessionService, IProgramService programService, IBlobService blobService)
        {
            EventService = eventService;
            SessionService = sessionService;
            ProgramService = programService;
            BlobService = blobService;
        }
    }
}
