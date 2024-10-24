using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using AutoMapper;
using EventService.Domain.DTOs;
using EventService.Domain.Entities;
using EventServices.Domain.Entities;

namespace EventServices.Application.Features.EventFeature.Commands;

public class EventCreateCmdHandler : IRequestHandler<EventCreateCmd, EventGetDTO>
{
    private readonly IUnitOfService _service;
    private readonly IMapper _mapper;
    public EventCreateCmdHandler(IUnitOfService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }




    public async Task<EventGetDTO> Handle(EventCreateCmd request, CancellationToken cancellationToken)
    {
        

        var @event = await _service.EventService.CreateAsync(_mapper.Map<Event>(request),request.ImageDetailEventFile,request.ImageListEventFile);
        return @event;
    }
}