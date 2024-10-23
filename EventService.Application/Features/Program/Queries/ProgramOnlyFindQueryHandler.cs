using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.Features.Program.Queries
{
    public class ProgramOnlyFindQueryHandler : IRequestHandler<ProgramOnlyFindQuery, ProgramOnlyGetDTO>
    {
        private readonly IUnitOfService _service;
        public ProgramOnlyFindQueryHandler(IUnitOfService service) => _service = service;




        public async Task<ProgramOnlyGetDTO> Handle(ProgramOnlyFindQuery request, CancellationToken cancellationToken)
        {
            var program = await _service.ProgramService.FindProgramOnlyAsync(request.Id);
            return program;
        }
    }
}
