using MediatR;
using EventServices.Domain.DTOs;

namespace EventServices.Application.Features.EventFeature.Commands;

public record EventUpdateCmd
(
    Guid Id,
    string Title,
    string? Address,
    string? Description,
    string? ImagePath,
    string? ImageListEventPath,
    DateTime? StartDate,
    DateTime? EndDate,
    Guid CityId,
    Guid ThemeId,
    Guid? ProgramId
) : IRequest<EventGetDTO>;