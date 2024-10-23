using AutoMapper;
using EventServices.Domain.DTOs;
using EventServices.Application.Interfaces;
using MediatR;

namespace EventServices.Application.Features.Slider.Commands.UpdateSlider;

public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand,SliderDto>
{
    private readonly IUnitOfService _unitOfService;
    private readonly IMapper _mapper;

    public UpdateSliderCommandHandler(IUnitOfService unitOfService, IMapper mapper)
    {
        _unitOfService = unitOfService;
        _mapper = mapper;
    }

    public async Task<SliderDto> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Slider slider = _mapper.Map<Domain.Entities.Slider>(request);
        return _mapper.Map<SliderDto>(await _unitOfService.SliderService.UpdateAsync(request.Id,slider));
    }
}