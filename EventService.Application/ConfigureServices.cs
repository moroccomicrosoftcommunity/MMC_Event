﻿using EventServices.Application.Interfaces;
using EventServices.Application.Mapping;
using EventServices.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace EventServices.Application
{
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
            //Services Injection
            services.AddScoped<IUnitOfService, UnitOfService>();
            services.AddScoped<IFileService,FileService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IEventService, Services.EventService>();
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<ISessionService, SessionService>();
            //Broker Injection
            var AlltheServices = services.BuildServiceProvider().GetService<IUnitOfService>();
            return services;
        }
    }
}