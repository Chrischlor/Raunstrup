using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaunstrupAuth.Models;

namespace RaunstrupAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        
        public DbSet<Adresse> Adresse { get; set; }
        public DbSet<Bynavn> Bynavn { get; set; }
        public DbSet<Indkøbsliste> Indkøbsliste { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Materialer> Materialer { get; set; }
        public DbSet<Medarbejder> Medarbejder { get; set; }
        public DbSet<Medarbejderliste> Medarbejderliste { get; set; }
        public DbSet<Projekt> Projekt { get; set; }
        public DbSet<Rabat> Rabat { get; set; }
        public DbSet<Speciale> Speciale { get; set; }
        public DbSet<Tilbud> Tilbud { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=den1.mssql8.gear.host;User ID=projektraunstrup;Password=Ro6000t_5!Ei;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }


        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Adresse>().ToTable("Adresse");
        //    modelBuilder.Entity<Bynavn>().ToTable("Bynavn");
        //    modelBuilder.Entity<Indkøbsliste>().ToTable("Indkøbsliste");
        //    modelBuilder.Entity<Kunde>().ToTable("Kunde");
        //    modelBuilder.Entity<Materialer>().ToTable("Materialer");
        //    modelBuilder.Entity<Medarbejder>().ToTable("Medarbejder");
        //    modelBuilder.Entity<Medarbejderliste>().ToTable("Medarbejderliste");
        //    modelBuilder.Entity<Projekt>().ToTable("Projekt");
        //    modelBuilder.Entity<Rabat>().ToTable("Rabat");
        //    modelBuilder.Entity<Speciale>().ToTable("Speciale");
        //    modelBuilder.Entity<Tilbud>().ToTable("Tilbud");
        //}
    }
}
