using EventService.Domain.Entities;
using EventServices.Application.Interfaces;
using EventServices.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;
using SpeakerService.Api.model;

namespace EventServices.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DevImagesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public DevImagesController(IUnitOfWork unitOfWork, IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }


    [HttpPatch("UpdateEvent")]
    public async Task<IActionResult> UpdateEvent([FromForm] DevEvent devEvent)
    {
        Event existingEvent = await _unitOfWork.EventRepository.GetAsync(devEvent.Id);
        if (existingEvent is null) return null;
        if (existingEvent.ImageDetailEventPath is not null && existingEvent.ImageDetailEventPath.Length > 0)
        {
            await _fileService.DeleteAsync(existingEvent.ImageDetailEventPath);
            existingEvent.ImageDetailEventPath = await _fileService.UploadAsync(devEvent.ImageDetailEventFile);
        }
        else
        {
            existingEvent.ImageDetailEventPath = await _fileService.UploadAsync(devEvent.ImageDetailEventFile);
        }
        if (existingEvent.ImageListEventPath is not null && existingEvent.ImageListEventPath.Length > 0)
        {
            await _fileService.DeleteAsync(existingEvent.ImageListEventPath);
            existingEvent.ImageListEventPath = await _fileService.UploadAsync(devEvent.ImageListEventFile);
        }
        else
        {
            existingEvent.ImageListEventPath = await _fileService.UploadAsync(devEvent.ImageListEventFile);
        }

        if (await _unitOfWork.CompleteAsync() > 0)
        {
            return Ok(await _unitOfWork.EventRepository.GetAsync(devEvent.Id));
        }
        return BadRequest("error enr");
    }
}