using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Commands;

public record EventUpdateCmd
(
    Guid Id,
    string Title,
    string? Address,
    string? Description,
    string? ImagePath,
    string? ImageSliderlPath,
    string? ImageListEventPath,
    DateTime? StartDate,
    DateTime? EndDate,
    Guid CityId,
    Guid ThemeId,
    Guid? ProgramId
) : IRequest<EventGetDTO>;