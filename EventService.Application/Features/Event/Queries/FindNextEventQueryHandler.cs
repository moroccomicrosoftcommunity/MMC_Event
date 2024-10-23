using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Event.Queries;

public class FindNextEventQueryHandler : IRequestHandler<FindNextEventQuery,IEnumerable<EventGetDTO>>
{
    private readonly IUnitOfService _unitOfService;

    public FindNextEventQueryHandler(IUnitOfService unitOfService)
    {
        _unitOfService = unitOfService;
    }

    public async Task<IEnumerable<EventGetDTO>> Handle(FindNextEventQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfService.EventService.FindNextEvent();
    }
}