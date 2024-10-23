namespace EventServices.Domain.Entities;

public class Slider
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string ImagePath { get; set; } = String.Empty;
    public bool IsDisabled { get; set; }
    public string MoreText { get; set; } = String.Empty;
    public string MoreLink { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}