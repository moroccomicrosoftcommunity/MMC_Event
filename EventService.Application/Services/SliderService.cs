using EventServices.Application.Interfaces;
using EventServices.Domain.Entities;
using EventServices.Application.IRepositories;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Services;

public class SliderService : ISliderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public SliderService(IUnitOfWork unitOfWork, IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<Slider?> FindAsync(Guid id)
    {
        return await _unitOfWork.SliderRepository.GetAsync(id);
    }

    public async Task<IEnumerable<Slider>> FindAllAsync()
    {
        return await _unitOfWork.SliderRepository.GetAllAsync();
    }

    public async Task<Slider?> CreateAsync(Slider slider,IFormFile file)
    {
        if (file is not null && file.Length > 0)
        {
            slider.ImagePath = await _fileService.UploadAsync(file);
        }
        if (!await _unitOfWork.SliderRepository.PostAsync(slider))
            return null;

        await _unitOfWork.CompleteAsync();
        return slider;
    }

    public async Task<Slider?> UpdateAsync(Guid id, Slider newSlider, IFormFile newFile)
    {
        Slider? existingSlider = await _unitOfWork.SliderRepository.GetAsync(id);
        if (existingSlider is null) return null;
        if (newFile is not null && newFile.Length > 0)
        {
            await _fileService.DeleteAsync(newSlider.ImagePath);
            newSlider.ImagePath = await _fileService.UploadAsync(newFile);
        }
        else
        {
            newSlider.ImagePath = existingSlider.ImagePath;
        }
        Slider slider = await _unitOfWork.SliderRepository.PutAsync(id, newSlider);
        if (slider is null) return null;
        await _unitOfWork.CompleteAsync();
        return slider;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        Slider slider = await _unitOfWork.SliderRepository.GetAsync(id);
        if (slider is null) return false;
        if (slider.ImagePath is not null) await _fileService.DeleteAsync(slider.ImagePath);
        bool success = await _unitOfWork.SliderRepository.RemoveAsync(id);
        await _unitOfWork.CompleteAsync();
        return success;
    }

    public async Task<IEnumerable<Slider>> FindAllIsNotDisable()
    {
        return await _unitOfWork.SliderRepository.GetAllAsync(s=>s.IsDisabled == false);
    }
    
}