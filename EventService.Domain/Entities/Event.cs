using EventService.Domain.Enums;
using EventServices.Domain.Entities;

namespace EventService.Domain.Entities;


public class Event
{
    public Guid Id { get;  set; } = Guid.NewGuid();
    public string? EventN { get;  set; }
    public string? Title { get;  set; }
    public string? Address { get;  set; }
    public string? Description { get;  set; }
    public string? ImagePath { get; set; }
    public string? ImageListEventPath { get; set; }

    public EventType? TypeEvent { get;  set; }
    public bool IsAvailable { get; set; } = false;
    public string? YoutubeLink { get; set; }
    public string? GalleryLink { get; set; }
    public EventStatus? EventStatus { get; set; }
    public DateTime? StartDate { get;  set; }
    public DateTime? EndDate { get;  set; }
    public Guid? CityId { get;  set; }
    public Guid? ProgramId { get;  set; } = null;
    public Program? Program { get;  set; }
    public Guid? ThemeId { get;  set; }
    public string? LinkRegister { get;  set; }
    
    public ICollection<Session>? Sessions { get;  set; }

    
}
