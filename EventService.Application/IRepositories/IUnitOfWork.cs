﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.IRepositories
{
    public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        ISessionRepository SessionRepository { get; }
        IProgramRepository ProgramRepository { get; }
        ISliderRepository SliderRepository { get; }
        Task<int> CompleteAsync();
    }
}
