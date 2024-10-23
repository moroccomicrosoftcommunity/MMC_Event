using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.Program.Commands;

public record ProgramCreateCmd(string Title) : IRequest<ProgramGetDTO>;