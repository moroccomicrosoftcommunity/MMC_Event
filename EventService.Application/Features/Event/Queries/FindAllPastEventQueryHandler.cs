using EventService.Domain.DTOs;
using EventServices.Application.Interfaces;
using MediatR;

namespace EventService.Application.Features.Event.Queries;

public class FindAllPastEventQueryHandler : IRequestHandler<FindAllPastEventQuery,IEnumerable<EventGetDTO>>
{
    private readonly IUnitOfService _unitOfService;

    public FindAllPastEventQueryHandler(IUnitOfService unitOfService)
    {
        _unitOfService = unitOfService;
    }

    public async Task<IEnumerable<EventGetDTO>> Handle(FindAllPastEventQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfService.EventService.FindAllPastEvent();
    }
}