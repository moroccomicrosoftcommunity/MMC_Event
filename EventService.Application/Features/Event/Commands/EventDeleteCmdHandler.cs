﻿using MediatR;
using EventServices.Application.Interfaces;

namespace EventServices.Application.Features.EventFeature.Commands;

public class EventDeleteCmdHandler : IRequestHandler<EventDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public EventDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(EventDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.EventService.DeleteAsync(request.Id);
        return success;
    }
}