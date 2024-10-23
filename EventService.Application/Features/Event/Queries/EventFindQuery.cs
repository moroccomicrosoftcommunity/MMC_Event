using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.EventFeature.Queries;

public record EventFindQuery(Guid Id) : IRequest<EventGetDTO>;