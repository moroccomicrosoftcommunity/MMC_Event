using AutoMapper;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using MediatR;

namespace EventServices.Application.Features.SliderFeature.Queries.GetAllSlidersNotDisabled;

public class GetAllSlidersNotDisabledQueryHandler : IRequestHandler<GetAllSlidersNotDisabledQuery,IEnumerable<SliderDto>>
{
    private readonly IUnitOfService _unitOfService;
    private readonly IMapper _mapper;

    public GetAllSlidersNotDisabledQueryHandler(IUnitOfService unitOfService, IMapper mapper)
    {
        _unitOfService = unitOfService;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<SliderDto>> Handle(GetAllSlidersNotDisabledQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<SliderDto>>(await _unitOfService.SliderService.FindAllIsNotDisable());
    }
}
