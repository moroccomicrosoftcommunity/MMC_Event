using AutoMapper;
using EventService.Domain.DTOs;
using EventService.Domain.Entities;
using EventServices.Application.Interfaces;
using MediatR;
namespace EventServices.Application.Features.EventFeature.Commands;
public class EventUpdateCmdHandler : IRequestHandler<EventUpdateCmd, EventGetDTO>
{
    private readonly IUnitOfService _service;
    private readonly IMapper _mapper;
    public EventUpdateCmdHandler(IUnitOfService service,IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    public async Task<EventGetDTO> Handle(EventUpdateCmd request, CancellationToken cancellationToken)
    {
        var @event = await _service.EventService.UpdateAsync(_mapper.Map<Event>(request),request.ImageDetailEventFile,request.ImageListEventFile);
        return @event;
    }
}