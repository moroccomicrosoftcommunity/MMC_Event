using MediatR;

namespace EventService.Application.Features.Slider.Commands.DeleteSlider;

public record DeleteSliderCommand(Guid Id) : IRequest<bool>;