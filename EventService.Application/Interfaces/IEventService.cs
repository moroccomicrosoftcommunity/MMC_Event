using EventServices.Domain.DTOs;
using EventServices.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventGetDTO> FindAsync(Guid id);
        Task<IEnumerable<EventGetDTO>> FindAllAsync();
        Task<IEnumerable<EventOnlyGetDTO>> FindAllEventOnlyAsync();
        Task<EventOnlyGetDTO> FindEventOnlyByIdAsync(Guid id);
        Task<EventGetDTO> CreateAsync(Event @event, IFormFile imageDetailEventFile, IFormFile imageListEventFile);
        Task<EventGetDTO> UpdateAsync(EventPutDTO eventPutDTO);
        Task<IEnumerable<EventGetDTO>> FindAllByProgramIdAsync(Guid Id);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<EventGetDTO>> FindAllPastEvent();
        Task<IEnumerable<EventGetDTO>> FindNextEvent();
    }
}
