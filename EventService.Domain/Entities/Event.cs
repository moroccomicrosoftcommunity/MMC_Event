namespace EventService.Domain.Entities;


public class Event
{
    //test
    public Guid Id { get; private set; }
    public string EventN { get; private set; }
    public string Title { get; private set; }
    public string? Address { get; private set; }
    public string? Description { get; private set; }
    public string? ImagePath { get; set; }
    public string?  ImageSliderlPath { get; set; }
    public string? ImageListEventPath { get; set; }
    public DateTime? StartDate { get; private set; }
    /// <summary>
    /// Le type d'evenement
    /// Webinnaire 
    /// Hypered
    /// Pre
    /// </summary>
    public int TypeEvent { get; private set; }
    public DateTime? EndDate { get; private set; }
    public Guid CityId { get; private set; }
    public Guid? ProgramId { get; private set; } = null;
    public Program? Program { get; private set; }
    public Guid? ThemeId { get; private set; }
    public string? LinkRegister { get; private set; }


    public ICollection<Session>? Sessions { get; private set; }

    public Event(string title, string? address, string? description, string? imagePath, DateTime? startDate, int typeEvent, string eventN, string? linkRegister, DateTime? endDate, Guid cityId, Guid? themeId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Address = address;
        Description = description;
        ImagePath = imagePath;
        StartDate = startDate;
        EndDate = endDate;
        CityId = cityId;
        ThemeId = themeId;
        TypeEvent = typeEvent;
        LinkRegister = linkRegister;
        EventN = eventN;
    }
}
