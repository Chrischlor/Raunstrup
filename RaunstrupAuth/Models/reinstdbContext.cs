using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Raunstrup.Models
{
    public partial class reinstdbContext : DbContext
    {
        public reinstdbContext()
        {
        }

        public reinstdbContext(DbContextOptions<reinstdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Bynavn> Bynavn { get; set; }
        public virtual DbSet<Indkøbsliste> Indkøbsliste { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Materialer> Materialer { get; set; }
        public virtual DbSet<Medarbejder> Medarbejder { get; set; }
        public virtual DbSet<Medarbejderliste> Medarbejderliste { get; set; }
        public virtual DbSet<Projekt> Projekt { get; set; }
        public virtual DbSet<Rabat> Rabat { get; set; }
        public virtual DbSet<Speciale> Speciale { get; set; }
        public virtual DbSet<Tilbud> Tilbud { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=den1.mssql7.gear.host;Initial Catalog=reinstdb;User ID=reinstdb;Password=Nm0Iu~71~jnB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasKey(e => e.Aid);

                entity.Property(e => e.Husnummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vejnavn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.By)
                    .WithMany(p => p.Adresse)
                    .HasForeignKey(d => d.Byid)
                    .HasConstraintName("FK__Adresse__Byid__412EB0B6");
            });

            modelBuilder.Entity<Bynavn>(entity =>
            {
                entity.HasKey(e => e.Byid);

                entity.Property(e => e.Navn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Indkøbsliste>(entity =>
            {
                entity.HasKey(e => e.Iid);

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Indkøbsliste)
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK__Indkøbslist__Rid__534D60F1");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Indkøbsliste)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__Indkøbslist__Tid__5165187F");

                entity.HasOne(d => d.VarenummerNavigation)
                    .WithMany(p => p.Indkøbsliste)
                    .HasForeignKey(d => d.Varenummer)
                    .HasConstraintName("FK__Indkøbsli__Varen__52593CB8");
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.HasKey(e => e.Kid);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Navn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tlf).HasColumnName("tlf");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Kunde)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK__Kunde__Aid__440B1D61");
            });

            modelBuilder.Entity<Materialer>(entity =>
            {
                entity.HasKey(e => e.Varenummer);

                entity.Property(e => e.Navn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medarbejder>(entity =>
            {
                entity.HasKey(e => e.Mid);

                entity.Property(e => e.Navn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Udd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Medarbejder)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK__Medarbejder__Aid__46E78A0C");

                entity.HasOne(d => d.Sp)
                    .WithMany(p => p.Medarbejder)
                    .HasForeignKey(d => d.Spid)
                    .HasConstraintName("FK__Medarbejde__Spid__47DBAE45");
            });

            modelBuilder.Entity<Medarbejderliste>(entity =>
            {
                entity.HasKey(e => e.Mlid);

                entity.Property(e => e.Mlid).HasColumnName("MLID");

                entity.HasOne(d => d.M)
                    .WithMany(p => p.Medarbejderliste)
                    .HasForeignKey(d => d.Mid)
                    .HasConstraintName("FK__Medarbejder__Mid__571DF1D5");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Medarbejderliste)
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK__Medarbejder__Rid__5812160E");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Medarbejderliste)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__Medarbejder__Tid__5629CD9C");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.Property(e => e.ProjektId).HasColumnName("ProjektID");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Projekt)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__Projekt__Tid__4E88ABD4");
            });

            modelBuilder.Entity<Rabat>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.Property(e => e.Rabat1)
                    .HasColumnName("Rabat")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Speciale>(entity =>
            {
                entity.HasKey(e => e.Spid);

                entity.Property(e => e.Speciale1)
                    .HasColumnName("Speciale")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tilbud>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Projekttitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Startdato).HasColumnType("date");

                entity.HasOne(d => d.K)
                    .WithMany(p => p.Tilbud)
                    .HasForeignKey(d => d.Kid)
                    .HasConstraintName("FK__Tilbud__Kid__4BAC3F29");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Tilbud)
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK__Tilbud__Rid__4AB81AF0");
            });
        }
    }
}
