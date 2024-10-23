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
    public class SessionFindAllQueryHandler : IRequestHandler<SessionFindAllQuery, IEnumerable<SessionGetDTO>>
    {
        private readonly IUnitOfService _service;
        public SessionFindAllQueryHandler(IUnitOfService service) => _service = service;




        public async Task<IEnumerable<SessionGetDTO>> Handle(SessionFindAllQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _service.SessionService.FindAllAsync();
            return sessions;
        }
    }
}
