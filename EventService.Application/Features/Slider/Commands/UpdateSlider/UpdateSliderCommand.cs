using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.Slider.Commands.UpdateSlider;

public record UpdateSliderCommand(    
    Guid Id,
    string Title,
    string Description,
    string ImagePath,
    bool IsDisabled,
    string MoreText,
    string MoreLink):IRequest<SliderDto>;