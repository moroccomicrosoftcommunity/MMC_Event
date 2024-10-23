using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.EventFeature.Queries;

public class EventOnlyFindByIdQueryHandler : IRequestHandler<EventOnlyFindByIdQuery, EventOnlyGetDTO>
{
    private readonly IUnitOfService _service;
    public EventOnlyFindByIdQueryHandler(IUnitOfService service) => _service = service;




    public async Task<EventOnlyGetDTO> Handle(EventOnlyFindByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await _service.EventService.FindEventOnlyByIdAsync(request.Id);
        return @event;
    }

   
}