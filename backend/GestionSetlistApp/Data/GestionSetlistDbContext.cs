using Microsoft.EntityFrameworkCore;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Data
{
    public class GestionSetlistDbContext : DbContext
    {
        public GestionSetlistDbContext(DbContextOptions<GestionSetlistDbContext> options) : base(options)
        {
            
        }

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<MembreJoueDe> MembreJoueDe { get; set; }
        public DbSet<MembreSetlist> MembreSetlist { get; set; }
        public DbSet<Morceau> Morceaux { get; set; }
        public DbSet<MorceauSetlist> MorceauSetlist { get; set; }
        public DbSet<Setlist> Setlists { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembreSetlist>().HasKey(ms => new { ms.MembreId, ms.SetlistId });

            modelBuilder.Entity<MorceauSetlist>().HasKey(mos => new { mos.MorceauId, mos.SetlistId });

            modelBuilder.Entity<MembreJoueDe>().HasKey(mj => new { mj.MembreId, mj.InstrumentId });
        }

    }
}
