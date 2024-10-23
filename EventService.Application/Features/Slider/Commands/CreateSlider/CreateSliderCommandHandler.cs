using AutoMapper;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;

namespace EventService.Application.Features.Slider.Commands.CreateSlider;

public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand,SliderDto>
{
    private readonly IUnitOfService _unitOfService;
    private readonly IMapper _mapper;

    public CreateSliderCommandHandler(IUnitOfService unitOfService, IMapper mapper)
    {
        _unitOfService = unitOfService;
        _mapper = mapper;
    }

    public async Task<SliderDto> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Slider slider = _mapper.Map<Domain.Entities.Slider>(request);
        return _mapper.Map<SliderDto>(await _unitOfService.SliderService.CreateAsync(slider));
    }
}