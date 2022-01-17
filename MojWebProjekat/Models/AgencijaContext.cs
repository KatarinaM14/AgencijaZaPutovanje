using Microsoft.EntityFrameworkCore;

namespace Models
{
      public class AgencijaContext : DbContext
      {
          public DbSet<Avion> Avioni { get; set; }

          public DbSet<Destinacija> Destinacije { get; set; }

          public DbSet<Klijent> Klijenti { get; set; }

          public DbSet<Spoj> KlijentAvion { get; set; }

          public DbSet<Vakcina>  Vakcinacija { get; set; }

          public  AgencijaContext(DbContextOptions options) : base(options)
          {

          }

           
      }
}