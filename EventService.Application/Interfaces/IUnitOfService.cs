using EventService.Application.Interfaces;

namespace EventServices.Application.Interfaces
{
    public interface IUnitOfService
    {

        IEventService EventService { get; }
        ISessionService SessionService { get; }
        IProgramService ProgramService { get; }
        ISliderService SliderService { get; }

    }
}
