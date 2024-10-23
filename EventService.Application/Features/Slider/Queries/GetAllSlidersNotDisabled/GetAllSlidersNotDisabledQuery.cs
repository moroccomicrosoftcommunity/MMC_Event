using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Queries.GetAllSlidersNotDisabled;

public record GetAllSlidersNotDisabledQuery():IRequest<IEnumerable<SliderDto>>;