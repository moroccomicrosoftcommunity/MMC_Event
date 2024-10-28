using AutoMapper;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using EventServices.Application.Interfaces;
using MediatR;

namespace EventServices.Application.Features.SliderFeature.Queries.GetAllSliders;

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