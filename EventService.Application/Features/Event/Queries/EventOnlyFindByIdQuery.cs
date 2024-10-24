using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventService.Domain.DTOs;
using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.EventFeature.Queries
{

    public record EventOnlyFindByIdQuery(Guid Id) : IRequest<EventOnlyGetDTO>;
}
