using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.Slider.Queries.GetAllSliders;

public record GetAllSlidersQuery() : IRequest<IEnumerable<SliderDto>>;