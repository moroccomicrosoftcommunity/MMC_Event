using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.SliderFeature.Queries.GetAllSliders;

public record GetAllSlidersQuery() : IRequest<IEnumerable<SliderDto>>;