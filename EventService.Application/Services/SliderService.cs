using EventServices.Application.Interfaces;
using EventServices.Domain.Entities;
using EventServices.Application.IRepositories;

namespace EventServices.Application.Services;

public class SliderService : ISliderService
{
    private readonly IUnitOfWork _unitOfWork;

    public SliderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Slider?> FindAsync(Guid id)
    {
        return await _unitOfWork.SliderRepository.GetAsync(id);
    }

    public async Task<IEnumerable<Slider>> FindAllAsync()
    {
        return await _unitOfWork.SliderRepository.GetAllAsync();
    }

    public async Task<Slider?> CreateAsync(Slider slider)
    {
        if (!await _unitOfWork.SliderRepository.PostAsync(slider))
            return null;

        await _unitOfWork.CompleteAsync();
        return slider;
    }

    public async Task<Slider?> UpdateAsync(Guid id, Slider newSlider)
    {
        Slider slider = await _unitOfWork.SliderRepository.PutAsync(id, newSlider);
        if (slider is null) return null;
        await _unitOfWork.CompleteAsync();
        return slider;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        bool success = await _unitOfWork.SliderRepository.RemoveAsync(id);
        await _unitOfWork.CompleteAsync();
        return success;
    }

    public async Task<IEnumerable<Slider>> FindAllIsNotDisable()
    {
        return await _unitOfWork.SliderRepository.GetAllAsync(s=>s.IsDisabled == false);
    }
    
}