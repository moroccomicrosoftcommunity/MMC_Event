using MediatR;
using EventService.Domain.DTOs;
using Azure.Core;

namespace EventService.Application.Features.Event.Commands;

public record EventCreateCmd
(
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