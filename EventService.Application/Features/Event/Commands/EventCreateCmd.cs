using MediatR;
using EventServices.Domain.DTOs;
using Azure.Core;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Features.EventFeature.Commands;

public record EventCreateCmd
(
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