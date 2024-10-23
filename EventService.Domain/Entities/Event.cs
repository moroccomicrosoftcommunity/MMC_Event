namespace EventServices.Domain.Entities;


public class Event
{
    //test 5
    public Guid Id { get;  set; }
    public string? EventN { get;  set; }
    public string? Title { get;  set; }
    public string? Address { get;  set; }
    public string? Description { get;  set; }
    public string? ImageDetailEventPath { get; set; }
    public string?  ImageSliderEventPath { get; set; }
    public string? ImageListEventPath { get; set; }
    public DateTime? StartDate { get;  set; }
    /// <summary>
    /// Le type d'evenement
    /// Webinnaire 
    /// Hypered
    /// Pre
    /// </summary>
    public int? TypeEvent { get;  set; }
    public DateTime? EndDate { get;  set; }
    public Guid? CityId { get;  set; }
    public Guid? ProgramId { get;  set; } = null;
    public Program? Program { get;  set; }
    public Guid? ThemeId { get;  set; }
    public string? LinkRegister { get;  set; }


    public ICollection<Session>? Sessions { get;  set; }

    
}
