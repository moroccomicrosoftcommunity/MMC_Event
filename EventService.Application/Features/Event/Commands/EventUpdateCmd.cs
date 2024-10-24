using EventService.Domain.DTOs;
using EventService.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Features.EventFeature.Commands;

public record EventUpdateCmd
(
    Guid Id,
    string Title,
    string? Address,
    string? Description,
    IFormFile? ImageDetailEventFile,
    IFormFile? ImageListEventFile,
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