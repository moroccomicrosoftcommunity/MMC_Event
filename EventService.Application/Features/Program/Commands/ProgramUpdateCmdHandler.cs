using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.Program.Commands;

public class ProgramUpdateCmdHandler : IRequestHandler<ProgramUpdateCmd, ProgramGetDTO>
{
    private readonly IUnitOfService _service;
    public ProgramUpdateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<ProgramGetDTO> Handle(ProgramUpdateCmd request, CancellationToken cancellationToken)
    {
        var programPutDTO = new ProgramPutDTO(request.Id, request.Title);
        var program = await _service.ProgramService.UpdateAsync(programPutDTO);
        return program;
    }
}