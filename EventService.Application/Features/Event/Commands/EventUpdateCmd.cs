using MediatR;
using EventServices.Domain.DTOs;
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
    DateTime? StartDate,
    DateTime? EndDate,
    Guid CityId,
    Guid ThemeId,
    Guid? ProgramId
) : IRequest<EventGetDTO>;