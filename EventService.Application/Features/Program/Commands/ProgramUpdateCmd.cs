using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.Program.Commands;

public record ProgramUpdateCmd(Guid Id,
        string Title)
    : IRequest<ProgramGetDTO>;