using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Commands.CreateSlider;

public record CreateSliderCommand(    
    string Title,
    string Description,
    string ImagePath,
    bool IsDisabled,
    string MoreText,
    string MoreLink) 
    : IRequest<SliderDto>;