using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TourAgency.Models;

namespace TourAgency.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Trips> Trips { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trips>().ToTable("Trip");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Place>().ToTable("Place");
            modelBuilder.Entity<Guide>().ToTable("Guide");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(login => new { login.LoginProvider, login.ProviderKey });

        }
    }
}