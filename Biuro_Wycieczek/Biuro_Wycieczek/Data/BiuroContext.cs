using Microsoft.EntityFrameworkCore;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Data
{
    public class BiuroContext : DbContext
    {


        public BiuroContext(DbContextOptions<BiuroContext> options) : base(options) 
        { 
        }

        public virtual DbSet<Trips> Trips { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trips>().ToTable("Trip");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Place>().ToTable("Trips");
            modelBuilder.Entity<Guide>().ToTable("Guide");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");

        }
    }
}
