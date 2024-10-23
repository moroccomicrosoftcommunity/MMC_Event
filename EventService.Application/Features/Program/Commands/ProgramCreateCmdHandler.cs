using MediatR;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using EventServices.Application.Features.Program.Commands;
using Azure.Core;

namespace EventServices.Application.Features.Program.Commands;

public class ProgramCreateCmdHandler : IRequestHandler<ProgramCreateCmd, ProgramGetDTO>
{
    private readonly IUnitOfService _service;
    public ProgramCreateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<ProgramGetDTO> Handle(ProgramCreateCmd request, CancellationToken cancellationToken)
    {
        var programPostDTO = new ProgramPostDTO(request.Title);
        var program = await _service.ProgramService.CreateAsync(programPostDTO);
        return program;
    }
}