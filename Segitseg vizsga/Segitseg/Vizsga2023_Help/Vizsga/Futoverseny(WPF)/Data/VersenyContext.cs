using Jedlik.EntityFramework.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoverseny.Data
{
    public class VersenyContext: JedlikDbContext
    {
        public DbSet<VersenyzoModel> Versenyzok { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = "Server=localhost;database=futoverseny;uid=root;pwd=;";
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(conString, ServerVersion.AutoDetect(conString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TavolsagModel>().HasData
                (
                    new TavolsagModel() { Id=1, Name="5 km"},
                    new TavolsagModel() { Id=2, Name="10 km"},
                    new TavolsagModel() { Id=3, Name="félmaraton"},
                    new TavolsagModel() { Id=4, Name="maraton"}
                );

            modelBuilder.Entity<VersenyzoModel>().HasData
                (
                    new VersenyzoModel() { Id=1, Nev="Béla", Korosztaly="senior", Neme="ffi", Rajtszam=5, TavolsagId=4},
                    new VersenyzoModel() { Id=2, Nev="Tünde", Korosztaly="junior", Neme="nő", Rajtszam=7, TavolsagId=1}
                );
        }
    }
}
