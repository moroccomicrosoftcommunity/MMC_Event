using MediatR;

namespace EventServices.Application.Features.EventFeature.Commands;

public record EventDeleteCmd(Guid Id) : IRequest<bool>;