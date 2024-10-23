using EventServices.Application.IRepositories;
using EventServices.Infrastructure.Repositories;
using EventServices.Application.IRepositories;
using EventServices.Infrastructure.Data;
using EventServices.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EventServices.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //database setup
            string? con = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IApplicationDbContext,ApplicationDbContext>(options => options.UseSqlServer(con));
            //dependency injection contanaire
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            return services;
        }
    }
}
