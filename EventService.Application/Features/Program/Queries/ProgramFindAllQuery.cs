using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.Program.Queries;

public record ProgramFindAllQuery : IRequest<IEnumerable<ProgramGetDTO>>;