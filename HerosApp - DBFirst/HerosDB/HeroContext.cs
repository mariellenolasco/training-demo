using Microsoft.EntityFrameworkCore;
using HerosDB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace HerosDB
{
    public class HeroContext:DbContext
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperVillain> SuperVillains { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!(optionsBuilder.IsConfigured))
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("HeroDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enemies>()
            .HasOne(enemy => enemy.Hero)
            .WithMany(hero => hero.Nemesis)
            .HasForeignKey(enemy => enemy.HeroID);

            modelBuilder.Entity<Enemies>()
            .HasOne(enemy => enemy.Villain)
            .WithMany(villain => villain.Nemesis)
            .HasForeignKey(enemy => enemy.VillainID);

            modelBuilder.Entity<Enemies>()
            .HasKey(e => e.EnemyID);
        }

    }
}