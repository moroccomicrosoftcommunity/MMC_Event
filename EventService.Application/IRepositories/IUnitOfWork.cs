using EventServices.Application.IRepositories;

namespace EventServices.Application.IRepositories
{
    public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        ISessionRepository SessionRepository { get; }
        IProgramRepository ProgramRepository { get; }
        ISliderRepository SliderRepository { get; }
        Task<int> CompleteAsync();
    }
}
