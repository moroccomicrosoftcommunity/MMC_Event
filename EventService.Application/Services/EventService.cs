using AutoMapper;
using EventService.Domain.DTOs;
using EventService.Domain.Entities;
using EventServices.Application.Interfaces;
using EventServices.Application.IRepositories;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        private readonly IFileService _fileService;
        public EventService(IUnitOfWork uow, IMapper map, IFileService fileService)
        {
            _uow = uow;
            _map = map;
            _fileService=fileService;
        }
        public async Task<EventGetDTO> FindAsync(Guid id)
        {
            var @event = await _uow.EventRepository.GetAsync(id,e=>e.Program,e=>e.Sessions);

            if (@event is null) return null;

            return _map.Map<EventGetDTO>(@event);
        }
        public async Task<EventOnlyGetDTO> FindEventOnlyByIdAsync(Guid id)
        {
            var @event = await _uow.EventRepository.FindEventOnlyByIdAsync(id);

            if (@event is null) return null;

            return _map.Map<EventOnlyGetDTO>(@event);
        }

        public async Task<IEnumerable<EventGetDTO>> FindAllByProgramIdAsync(Guid Id)
        {
            var events = await _uow.EventRepository.GetEventsByProgramId(Id);

            if (events is null) return null;

            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }
        public async Task<IEnumerable<EventGetDTO>> FindAllAsync()
        {
            var events = await _uow.EventRepository.GetAllAsync(null,e => e.Program, e => e.Sessions);

            if (events is null) return null;

            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }
        public async Task<EventGetDTO> CreateAsync(Event @event, IFormFile imageDetailEventFile, IFormFile imageListEventFile)
        {
            if (imageDetailEventFile is not null && imageDetailEventFile.Length > 0)
            {
                @event.ImageDetailEventPath = await _fileService.UploadAsync(imageDetailEventFile);
            }
            if (imageListEventFile is not null && imageListEventFile.Length > 0)
            {
                @event.ImageListEventPath = await _fileService.UploadAsync(imageListEventFile);
            }
            if (!await _uow.EventRepository.PostAsync(@event))
                return null;
            await _uow.CompleteAsync();
            var createdEvent = await FindAsync(@event.Id);
            return createdEvent;
        }
        public async Task<EventGetDTO> UpdateAsync(Event @event, IFormFile imageDetailEventFile, IFormFile imageListEventFile)
        {
            Event existingEvent = await _uow.EventRepository.GetAsync(@event.Id);
            if (existingEvent is null) return null;
            if (imageDetailEventFile is not null && imageDetailEventFile.Length > 0)
            {
                await _fileService.DeleteAsync(existingEvent.ImageDetailEventPath);
                @event.ImageDetailEventPath = await _fileService.UploadAsync(imageDetailEventFile);
            }
            else
            {
                @event.ImageDetailEventPath = existingEvent.ImageDetailEventPath;
            }
            if (imageListEventFile is not null && imageListEventFile.Length > 0)
            {
                await _fileService.DeleteAsync(existingEvent.ImageListEventPath);
                @event.ImageListEventPath = await _fileService.UploadAsync(imageListEventFile);
            }
            else
            {
                @event.ImageListEventPath = existingEvent.ImageListEventPath;
            }
            var updatedEvent = await _uow.EventRepository.PutAsync(@event.Id, @event);
            await _uow.CompleteAsync();
            return _map.Map<EventGetDTO>(updatedEvent);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var @event = await _uow.EventRepository.GetAsync(id);
            if (@event is null) return false;
            if(@event.ImageDetailEventPath is not null) await _fileService.DeleteAsync(@event.ImageDetailEventPath);
            if (@event.ImageListEventPath is not null) await _fileService.DeleteAsync(@event.ImageListEventPath);
            var success = await _uow.EventRepository.RemoveAsync(id);
            await _uow.CompleteAsync();
            return success;
        }
        public async Task<IEnumerable<EventOnlyGetDTO>> FindAllEventOnlyAsync()
        {
            var events = await _uow.EventRepository.GetAllAsync();

            if (events is null) return null;

            return _map.Map<IEnumerable<EventOnlyGetDTO>>(events);
        }

        public async Task<IEnumerable<EventGetDTO>> FindAllPastEvent()
        {
            IEnumerable<Event> events = await _uow.EventRepository.GetAllAsync( e => e.EndDate < DateTime.Today);
            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }

        public async Task<IEnumerable<EventGetDTO>> FindNextEvent()
        {
            IEnumerable<Event> events = await _uow.EventRepository.GetAllAsync(e=>e.StartDate >= DateTime.Today && e.IsAvailable);
            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }
    }
}
