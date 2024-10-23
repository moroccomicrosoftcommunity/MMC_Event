using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.EventFeature.Queries;

public record EventFindAllQuery : IRequest<IEnumerable<EventGetDTO>>;