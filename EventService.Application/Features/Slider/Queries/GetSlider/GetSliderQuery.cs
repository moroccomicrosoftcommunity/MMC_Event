using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.Slider.Queries.GetSlider;

public record GetSliderQuery(Guid id) : IRequest<SliderDto>;