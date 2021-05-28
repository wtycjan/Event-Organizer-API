using event_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_API.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Participant>().ToTable("Participant");

            // Configure Primary Keys  
            modelBuilder.Entity<Event>().HasKey(u => u.Id).HasName("PK_Event");
            modelBuilder.Entity<Participant>().HasKey(u => u.Id).HasName("PK_Participant");

            // Configure columns  
            modelBuilder.Entity<Event>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.StartTime).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<Participant>().Property(p => p.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Participant>().Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Participant>().Property(p => p.Email).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Participant>().Property(p => p.EventId).HasColumnType("int").IsRequired();

            // Configure relationships  
            modelBuilder.Entity<Participant>().HasOne<Event>().WithMany().HasPrincipalKey(e => e.Id).HasForeignKey(p => p.EventId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Participant_Event");
        }
    }
}  
