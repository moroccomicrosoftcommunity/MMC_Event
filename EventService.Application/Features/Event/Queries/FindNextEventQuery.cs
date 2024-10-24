using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Event.Queries;

public record FindNextEventQuery(): IRequest<IEnumerable<EventGetDTO>>;