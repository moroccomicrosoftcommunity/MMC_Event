using AutoMapper;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using EventServices.Application.Interfaces;
using MediatR;

namespace EventServices.Application.Features.Slider.Commands.CreateSlider;

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