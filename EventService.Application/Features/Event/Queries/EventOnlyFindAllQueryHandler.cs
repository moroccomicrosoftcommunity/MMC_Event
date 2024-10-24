using EventService.Domain.DTOs;
using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.EventFeature.Queries;

public class EventOnlyFindAllQueryHandler : IRequestHandler<EventOnlyFindAllQuery, IEnumerable<EventOnlyGetDTO>>
{
    private readonly IUnitOfService _service;
    public EventOnlyFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<EventOnlyGetDTO>> Handle(EventOnlyFindAllQuery request, CancellationToken cancellationToken)
    {
        var events = await _service.EventService.FindAllEventOnlyAsync();
        return events;
    }

    
}