using AutoMapper;
using EventServices.Application.Interfaces;
using EventServices.Application.IRepositories;
using EventServices.Domain.DTOs;
using EventServices.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        private readonly IBlobService _blobService;
        public EventService(IUnitOfWork uow, IMapper map, IBlobService blobService)
        {
            _uow = uow;
            _map = map;
            _blobService = blobService;
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
            var events = await _uow.EventRepository.GetAllAsync(e => e.Program, e => e.Sessions);

            if (events is null) return null;

            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }
        public async Task<EventGetDTO> CreateAsync(Event @event, IFormFile imageDetailEventFile, IFormFile imageListEventFile)
        {
            @event.Id = Guid.NewGuid();
            @event.ImageDetailEventPath = await HandleFileUpload(@event.Id, imageDetailEventFile);
            @event.ImageListEventPath = await HandleFileUpload(@event.Id, imageListEventFile);
            if (!await _uow.EventRepository.PostAsync(@event))
                return null;
            await _uow.CompleteAsync();
            var createdEvent = await FindAsync(@event.Id);
            return createdEvent;
        }
        public async Task<EventGetDTO> UpdateAsync(EventPutDTO eventPutDTO)
        {
            var @event = _map.Map<Event>(eventPutDTO);
            var updatedEvent = await _uow.EventRepository.PutAsync(@event.Id, @event);

            await _uow.CompleteAsync();
            return _map.Map<EventGetDTO>(updatedEvent);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
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
        public async Task<string> HandleFileUpload(Guid eventId, IFormFile file)
        {
            if (file is not null)
            {
                return await _blobService.UploadAsync(eventId, file);
            }
            else
            {
                return "string";
            }
        }
    }
}
