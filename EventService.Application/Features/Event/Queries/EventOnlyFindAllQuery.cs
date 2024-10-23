using EventService.Domain.DTOs;
using MediatR;



namespace EventServices.Application.Features.EventFeature.Queries;

public record EventOnlyFindAllQuery : IRequest<IEnumerable<EventOnlyGetDTO>>;