using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.Features.Session.Queries
{

    public class SessionOnlyFindByIdQueryHandler : IRequestHandler<SessionOnlyFindByIdQuery, SessionOnlyGetDTO>
    {
        private readonly IUnitOfService _service;
        public SessionOnlyFindByIdQueryHandler(IUnitOfService service) => _service = service;




        public async Task<SessionOnlyGetDTO> Handle(SessionOnlyFindByIdQuery request, CancellationToken cancellationToken)
        {
            var session = await _service.SessionService.FindSessionOnlyByIdAsync(request.Id);
            return session;
        }

        
    }
}
