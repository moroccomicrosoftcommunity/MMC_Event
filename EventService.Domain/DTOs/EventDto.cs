using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventService.Domain.Enums;
using EventServices.Domain.DTOs;

namespace EventService.Domain.DTOs
{

    public record EventGetDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImagePath,
        string? ImageListEventPath,
        EventType? TypeEvent,
        bool IsAvailable,
        string? YoutubeLink,
        string? GalleryLink,
        EventStatus? EventStatus,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId, 
        Guid ProgramId,
        ProgramOnlyGetDTO Program,
        ICollection<SessionGetDTO>   Sessions,
        Guid ThemeId

    );

    public record EventOnlyGetDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        EventType? TypeEvent,
        bool IsAvailable,
        string? YoutubeLink,
        string? GalleryLink,
        EventStatus? EventStatus,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ProgramId,
        Guid ThemeId

    );

    public record EventPostDTO
    (
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        EventType? TypeEvent,
        bool IsAvailable,
        string? YoutubeLink,
        string? GalleryLink,
        EventStatus? EventStatus,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ThemeId,
        Guid? ProgramId
    );

    public record EventPutDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        EventType? TypeEvent,
        bool IsAvailable,
        string? YoutubeLink,
        string? GalleryLink,
        EventStatus? EventStatus,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ThemeId,
        Guid? ProgramId
    );
}
