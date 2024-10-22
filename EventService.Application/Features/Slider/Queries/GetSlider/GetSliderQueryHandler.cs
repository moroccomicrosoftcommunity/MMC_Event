using AutoMapper;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Queries.GetSlider;

public class GetSliderQueryHandler : IRequestHandler<GetSliderQuery,SliderDto>
{
    private readonly IUnitOfService _unitOfService;
    private readonly IMapper _mapper;

    public GetSliderQueryHandler(IUnitOfService unitOfService, IMapper mapper)
    {
        _unitOfService = unitOfService;
        _mapper = mapper;
    }

    public async Task<SliderDto> Handle(GetSliderQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<SliderDto>(await _unitOfService.SliderService.FindAsync(request.id));
    }
}