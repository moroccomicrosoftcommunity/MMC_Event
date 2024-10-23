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
<<<<<<< HEAD
        IBlobService BlobService { get; }
=======
        ISliderService SliderService { get; }
>>>>>>> a18fd5604255217c475018b9cb6419b7aaa6a2a1

    }
}
