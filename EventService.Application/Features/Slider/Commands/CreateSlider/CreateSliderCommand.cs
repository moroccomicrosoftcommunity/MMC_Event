using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.Slider.Commands.CreateSlider;

public record CreateSliderCommand(    
    string Title,
    string Description,
    string ImagePath,
    bool IsDisabled,
    string MoreText,
    string MoreLink) 
    : IRequest<SliderDto>;