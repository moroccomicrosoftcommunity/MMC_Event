using MediatR;
using EventService.Domain.DTOs;
using EventService.Domain.Enums;

namespace EventServices.Application.Features.EventFeature.Commands;

public record EventUpdateCmd
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
    Guid ThemeId,
    Guid? ProgramId
) : IRequest<EventGetDTO>;