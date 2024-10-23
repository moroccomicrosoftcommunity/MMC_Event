using EventService.Domain.DTOs;
using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
namespace EventServices.Application.Features.EventFeature.Commands;
public class EventUpdateCmdHandler : IRequestHandler<EventUpdateCmd, EventGetDTO>
{
    private readonly IUnitOfService _service;
    public EventUpdateCmdHandler(IUnitOfService service) => _service = service;
    public async Task<EventGetDTO> Handle(EventUpdateCmd request, CancellationToken cancellationToken)
    {
        var eventPutDTO = new EventPutDTO
        (
            request.Id,
            request.Title,
            request.Address,
            request.Description,
            request.ImagePath,
            request.ImageListEventPath,
            request.TypeEvent,
            request.IsAvailable,
            request.YoutubeLink,
            request. GalleryLink,
            request.EventStatus,
            request.StartDate,
            request.EndDate,
            request.CityId,
            request.ThemeId,
            request.ProgramId
        );
        var @event = await _service.EventService.UpdateAsync(eventPutDTO);
        return @event;
    }
}