using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Queries.GetSlider;

public record GetSliderQuery(Guid id) : IRequest<SliderDto>;