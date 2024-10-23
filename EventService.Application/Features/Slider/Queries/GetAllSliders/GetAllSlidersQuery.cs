using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Queries.GetAllSliders;

public record GetAllSlidersQuery() : IRequest<IEnumerable<SliderDto>>;