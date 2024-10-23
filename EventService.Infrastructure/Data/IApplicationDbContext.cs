﻿using EventServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
