using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductivityTools.Meetings.Database.Objects;
using System;

namespace ProductivityTools.Meetings.Database
{
    public class MeetingContext : DbContext
    {
        private readonly IConfiguration configuration;

        public MeetingContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Meeting> Meeting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Meetings"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tm");
            modelBuilder.Entity<Meeting>().HasKey(x => x.MeetingId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
