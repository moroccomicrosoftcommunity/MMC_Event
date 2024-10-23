using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.Features.EventFeature.Queries
{
    public class EventFindAllByProgramIdQueryHandler : IRequestHandler<EventFindAllByProgramIdQuery, IEnumerable<EventGetDTO>>
    {
        private readonly IUnitOfService _service;
        public EventFindAllByProgramIdQueryHandler(IUnitOfService service) => _service = service;




        public async Task<IEnumerable<EventGetDTO>> Handle(EventFindAllByProgramIdQuery request, CancellationToken cancellationToken)
        {

            var events = await _service.EventService.FindAllByProgramIdAsync(request.Id);
            return events;
        }

        
    }
}
