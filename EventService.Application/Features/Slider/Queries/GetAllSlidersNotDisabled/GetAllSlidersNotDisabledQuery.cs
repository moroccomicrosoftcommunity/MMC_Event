using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.SliderFeature.Queries.GetAllSlidersNotDisabled;

public record GetAllSlidersNotDisabledQuery():IRequest<IEnumerable<SliderDto>>;