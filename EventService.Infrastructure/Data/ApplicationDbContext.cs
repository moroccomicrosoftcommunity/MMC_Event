using EventService.Domain.Entities;
using EventServices.Domain.Entities;
using EventServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventServices.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Event> Events { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        public new DbSet<T> Set<T>() where T : class => base.Set<T>();


        public async Task<int> SaveChangesAsync()
            => await base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
           .HasOne(e => e.Program)
           .WithMany(p => p.Events)
           .HasForeignKey(e => e.ProgramId)
           .IsRequired(false);

            modelBuilder.Entity<Program>()
            .HasMany(p => p.Events)            
            .WithOne(e => e.Program)           
            .HasForeignKey(e => e.ProgramId)
            .IsRequired(false);

            modelBuilder.Entity<Session>()
                .HasOne(e=>e.Event)
                .WithMany(p => p.Sessions).HasForeignKey(e=>e.EventId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
