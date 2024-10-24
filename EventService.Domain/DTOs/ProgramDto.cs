﻿using EventService.Domain.Entities;
using EventServices.Domain.Entities;

namespace EventServices.Domain.DTOs
{
    public record ProgramGetDTO
    (
        Guid Id,
        string Title,
        ICollection<Event>? Events
    );
    public record ProgramOnlyGetDTO
    (
        Guid Id,
        string Title
    );

    public record ProgramPostDTO
    (
            string Title
    );
    

    public record ProgramPutDTO
    (
        Guid Id,
        string Title
    );
}
