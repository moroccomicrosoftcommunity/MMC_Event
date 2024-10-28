using EventServices.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Interfaces;

public interface ISliderService
{
    Task<Slider?> FindAsync(Guid id);
    Task<IEnumerable<Slider>> FindAllAsync();
    Task<Slider?> CreateAsync(Slider slider,IFormFile file);
    Task<Slider?> UpdateAsync(Guid id, Slider newSlider,IFormFile newFile);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Slider>> FindAllIsNotDisable();
}