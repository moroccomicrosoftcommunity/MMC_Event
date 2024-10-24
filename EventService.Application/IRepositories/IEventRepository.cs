﻿using EventServices.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventService.Domain.Entities;

namespace EventServices.Application.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsByProgramId(Guid Id, params Expression<Func<Event, object>>[] includes);

        Task<Event> FindEventOnlyByIdAsync(Guid Id, params Expression<Func<Event, object>>[] includes);

    }
}
