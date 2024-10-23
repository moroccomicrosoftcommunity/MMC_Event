﻿using AutoMapper;
using EventService.Application.Interfaces;
using MediatR;

namespace EventService.Application.Features.Slider.Commands.DeleteSlider;

public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand,bool>
{
    private readonly IUnitOfService _unitOfService;

    public DeleteSliderCommandHandler(IUnitOfService unitOfService)
    {
        _unitOfService = unitOfService;
    }

    public async Task<bool> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfService.SliderService.DeleteAsync(request.Id);
    }
}