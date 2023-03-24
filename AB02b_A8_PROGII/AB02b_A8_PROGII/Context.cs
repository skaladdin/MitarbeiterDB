using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AB02b_A8_PROGII
{
    internal class Context : DbContext
    {
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Organisationseinheit> Organisationseinheiten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MitarbeiterDB;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitarbeiter>().HasKey(m => m.MitarbeiterID); //Primärschlüssel
            modelBuilder.Entity<Organisationseinheit>().HasKey(o => o.OeID);

            modelBuilder.Entity<Mitarbeiter>().HasOne(m => m.Organisationseinheit) // 1er Beziehung
                .WithMany(o => o.Mitarbeiter) // m-beziehung
                .HasForeignKey(m => m.OeID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
