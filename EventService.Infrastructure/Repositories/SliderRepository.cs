using EventServices.Application.IRepositories;
using EventServices.Domain.Entities;
using EventServices.Infrastructure.Data;
using EventServices.Infrastructure.Repositories;

namespace EventServices.Infrastructure.Repositories;

public class SliderRepository : Repository<Slider>, ISliderRepository
{
    private readonly IApplicationDbContext _db;
    public SliderRepository(IApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}