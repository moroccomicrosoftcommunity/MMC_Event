using EventServices.Application.Interfaces;
using EventServices.Application.Mapping;
using EventServices.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper registration
        services.AddAutoMapper(typeof(AutoMapperProfile));

        // MediatR registration
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        // Services Injection
        services.AddScoped<IUnitOfService, UnitOfService>();
        services.AddTransient<IBlobService, BlobService>();
        services.AddTransient<ISessionService, SessionService>();
        services.AddTransient<IProgramService, ProgramService>();
        services.AddTransient<IEventService, EventService>();

        // Broker Injection - Use a factory method to resolve IUnitOfService
        services.AddSingleton<RabbitMQServer>(serviceProvider =>
        {
            var unitOfService = serviceProvider.GetRequiredService<IUnitOfService>();
            return new RabbitMQServer(unitOfService);
        });

        return services;
    }
}
