using EventServices.Application.Interfaces;

namespace EventServices.Application.Services
{
    public class UnitOfService : IUnitOfService
    {
        public IEventService EventService { get; private set; }
        public ISessionService SessionService { get; private set; }
        public IProgramService ProgramService { get; private set; }
<<<<<<< HEAD
        public IBlobService BlobService { get; private set; }
        public UnitOfService(IEventService eventService, ISessionService sessionService, IProgramService programService, IBlobService blobService)
        {
            EventService = eventService;
            SessionService = sessionService;
            ProgramService = programService;
            BlobService = blobService;
=======
        public ISliderService SliderService { get; private set; }

        public UnitOfService(IUnitOfWork uow, IMapper map, IEventService eventService, ISessionService sessionService, IProgramService programService, ISliderService sliderService)
        {
            _uow = uow;
            _map = map;
            EventService = eventService;
            SessionService = sessionService;
            ProgramService = programService;
            SliderService = sliderService;
>>>>>>> a18fd5604255217c475018b9cb6419b7aaa6a2a1
        }
    }
}
