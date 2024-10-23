using EventService.Application.IRepositories;
using EventService.Domain.Entities;
using EventService.Infrastructure.Data;

namespace EventService.Infrastructure.Repositories;

public class SliderRepository : Repository<Slider>, ISliderRepository
{
    private readonly IApplicationDbContext _db;
    public SliderRepository(IApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}