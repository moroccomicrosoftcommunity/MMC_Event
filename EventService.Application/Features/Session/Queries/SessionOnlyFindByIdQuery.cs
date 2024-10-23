using EventServices.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.Features.Session.Queries
{
    public record SessionOnlyFindByIdQuery(Guid Id) : IRequest<SessionOnlyGetDTO>;
}
