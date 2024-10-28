using EventServices.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Features.SliderFeature.Commands.UpdateSlider;

public record UpdateSliderCommand(    
    Guid Id,
    string Title,
    string Description,
    IFormFile? ImageFile,
    bool IsDisabled,
    string MoreText,
    string MoreLink):IRequest<SliderDto>;