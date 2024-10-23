using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.Slider.Queries.GetAllSlidersNotDisabled;

public record GetAllSlidersNotDisabledQuery():IRequest<IEnumerable<SliderDto>>;