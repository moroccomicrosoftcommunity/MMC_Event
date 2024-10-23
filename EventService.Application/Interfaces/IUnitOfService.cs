using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServices.Application.Interfaces
{
    public interface IUnitOfService
    {

        IEventService EventService { get; }
        ISessionService SessionService { get; }
        IProgramService ProgramService { get; }
        IBlobService BlobService { get; }

    }
}
