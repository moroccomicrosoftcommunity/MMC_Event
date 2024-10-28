using MediatR;

namespace EventServices.Application.Features.SliderFeature.Commands.DeleteSlider;

public record DeleteSliderCommand(Guid Id) : IRequest<bool>;