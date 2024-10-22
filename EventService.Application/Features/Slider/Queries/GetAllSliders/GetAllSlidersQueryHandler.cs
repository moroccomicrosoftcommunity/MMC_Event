using AutoMapper;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Queries.GetAllSliders;

public class GetAllSlidersQueryHandler : IRequestHandler<GetAllSlidersQuery,IEnumerable<SliderDto>>
{
    private readonly IUnitOfService _unitOfService;
    private readonly IMapper _mapper;

    public GetAllSlidersQueryHandler(IUnitOfService unitOfService, IMapper mapper)
    {
        _unitOfService = unitOfService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SliderDto>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<SliderDto>>(await _unitOfService.SliderService.FindAllAsync());
    }
}