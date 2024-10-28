using AutoMapper;
using EventServices.Application.Interfaces;
using EventServices.Domain.DTOs;
using EventServices.Application.Interfaces;
using MediatR;
using EventServices.Domain.Entities;

namespace EventServices.Application.Features.SliderFeature.Commands.CreateSlider;

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
        Slider slider = _mapper.Map<Slider>(request);
        return _mapper.Map<SliderDto>(await _unitOfService.SliderService.CreateAsync(slider,request.ImageFile));
    }
}