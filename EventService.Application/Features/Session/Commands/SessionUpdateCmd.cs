using EventServices.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.Features.Session.Commands
{
    public record SessionUpdateCmd
 (
     Guid Id,
     string Name,
     int NumPlace,
     string? Description,
     DateTime? StartDate,
     DateTime? EndDate,
     Guid EventId,
     Guid ModeId
 ) : IRequest<SessionGetDTO>;
}
