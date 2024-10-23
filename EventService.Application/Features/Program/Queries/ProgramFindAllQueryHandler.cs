using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using EventServices.Application.Features.Program.Queries;

namespace EventServices.Application.Features.Program.Queries;

public class ProgramFindAllQueryHandler : IRequestHandler<ProgramFindAllQuery, IEnumerable<ProgramGetDTO>>
{
    private readonly IUnitOfService _service;
    public ProgramFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<ProgramGetDTO>> Handle(ProgramFindAllQuery request, CancellationToken cancellationToken)
    {
        var program= await _service.ProgramService.FindAllAsync();
        return program;
    }
}