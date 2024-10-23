using MediatR;

namespace EventServices.Application.Features.Slider.Commands.DeleteSlider;

public record DeleteSliderCommand(Guid Id) : IRequest<bool>;