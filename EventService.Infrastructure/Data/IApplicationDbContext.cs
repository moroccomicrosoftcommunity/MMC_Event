using EventService.Domain.Entities;
using EventServices.Domain.Entities;
using EventServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventServices.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        
        DbSet<Event> Events { get; set; }
        DbSet<Program> Programs{ get; set; }
        DbSet <Session> Sessions { get; set; }  
        DbSet<Slider> Sliders { get; set; }
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
