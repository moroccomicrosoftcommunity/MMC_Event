using EventService.Domain.Entities;

namespace EventService.Application.Interfaces;

public interface ISliderService
{
    Task<Slider?> FindAsync(Guid id);
    Task<IEnumerable<Slider>> FindAllAsync();
    Task<Slider?> CreateAsync(Slider slider);
    Task<Slider?> UpdateAsync(Guid id, Slider newSlider);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Slider>> FindAllIsNotDisable();
}