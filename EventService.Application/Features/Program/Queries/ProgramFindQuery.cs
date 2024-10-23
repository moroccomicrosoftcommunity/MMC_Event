using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.Program.Queries;

public record ProgramFindQuery(Guid Id) : IRequest<ProgramGetDTO>;