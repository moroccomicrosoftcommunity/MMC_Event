using MediatR;

namespace EventServices.Application.Features.Program.Commands;

public record ProgramDeleteCmd(Guid Id) : IRequest<bool>;