using EventService.Domain.Entities;

namespace EventServices.Domain.Entities
{
    public class Program
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public ICollection<Event>? Events { get; private set; }

        public Program(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            
        }
    }
}
