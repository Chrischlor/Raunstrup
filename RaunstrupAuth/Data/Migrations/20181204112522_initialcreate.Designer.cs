﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaunstrupAuth.Data;

namespace RaunstrupAuth.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181204112522_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Adresse", b =>
                {
                    b.Property<int>("AID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Byid");

                    b.Property<string>("Husnummer");

                    b.Property<string>("Vejnavn");

                    b.HasKey("AID");

                    b.HasIndex("Byid");

                    b.ToTable("Adresse");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Bynavn", b =>
                {
                    b.Property<int>("ByID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Navn");

                    b.Property<int>("Postnummer");

                    b.HasKey("ByID");

                    b.ToTable("Bynavn");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Indkøbsliste", b =>
                {
                    b.Property<int>("IID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Antal");

                    b.Property<int?>("Rid");

                    b.Property<int?>("Tid");

                    b.Property<int?>("Varenummer");

                    b.Property<int?>("VarenummerNavigationmaterialeID");

                    b.HasKey("IID");

                    b.HasIndex("Rid");

                    b.HasIndex("Tid");

                    b.HasIndex("VarenummerNavigationmaterialeID");

                    b.ToTable("Indkøbsliste");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Kunde", b =>
                {
                    b.Property<int>("Kid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Aid");

                    b.Property<string>("Mail");

                    b.Property<string>("Navn");

                    b.Property<int?>("Tlf");

                    b.HasKey("Kid");

                    b.HasIndex("Aid");

                    b.ToTable("Kunde");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Materialer", b =>
                {
                    b.Property<int>("materialeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Indkøbspris");

                    b.Property<string>("Navn");

                    b.Property<int?>("Salgspris");

                    b.HasKey("materialeID");

                    b.ToTable("Materialer");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Medarbejder", b =>
                {
                    b.Property<int>("MID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aid");

                    b.Property<bool>("Fudd");

                    b.Property<string>("Navn");

                    b.Property<int>("SpecialeID");

                    b.Property<int>("Tlf");

                    b.Property<string>("Udd");

                    b.HasKey("MID");

                    b.HasIndex("Aid");

                    b.HasIndex("SpecialeID");

                    b.ToTable("Medarbejder");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Medarbejderliste", b =>
                {
                    b.Property<int>("Mlid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mid");

                    b.Property<int>("Rid");

                    b.Property<int>("Tid");

                    b.Property<int>("Timer");

                    b.HasKey("Mlid");

                    b.HasIndex("Mid");

                    b.HasIndex("Rid");

                    b.HasIndex("Tid");

                    b.ToTable("Medarbejderliste");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Projekt", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Tid");

                    b.HasKey("Pid");

                    b.HasIndex("Tid");

                    b.ToTable("Projekt");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Rabat", b =>
                {
                    b.Property<int>("Rid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rabat1");

                    b.HasKey("Rid");

                    b.ToTable("Rabat");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Speciale", b =>
                {
                    b.Property<int>("Spid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SpecialeNavn");

                    b.HasKey("Spid");

                    b.ToTable("Speciale");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Tilbud", b =>
                {
                    b.Property<int>("Tid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Deadline");

                    b.Property<int>("Kid");

                    b.Property<string>("Projekttitle");

                    b.Property<int>("Rid");

                    b.Property<DateTime>("Startdato");

                    b.HasKey("Tid");

                    b.HasIndex("Kid");

                    b.HasIndex("Rid");

                    b.ToTable("Tilbud");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Adresse", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Bynavn", "By")
                        .WithMany("Adresse")
                        .HasForeignKey("Byid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Indkøbsliste", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Rabat", "R")
                        .WithMany("Indkøbsliste")
                        .HasForeignKey("Rid");

                    b.HasOne("RaunstrupAuth.Models.Tilbud", "T")
                        .WithMany("Indkøbsliste")
                        .HasForeignKey("Tid");

                    b.HasOne("RaunstrupAuth.Models.Materialer", "VarenummerNavigation")
                        .WithMany("Indkøbsliste")
                        .HasForeignKey("VarenummerNavigationmaterialeID");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Kunde", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Adresse", "A")
                        .WithMany("Kunde")
                        .HasForeignKey("Aid");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Medarbejder", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Adresse", "A")
                        .WithMany("Medarbejder")
                        .HasForeignKey("Aid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RaunstrupAuth.Models.Speciale", "S")
                        .WithMany()
                        .HasForeignKey("SpecialeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Medarbejderliste", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Medarbejder", "M")
                        .WithMany("Medarbejderliste")
                        .HasForeignKey("Mid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RaunstrupAuth.Models.Rabat", "R")
                        .WithMany("Medarbejderliste")
                        .HasForeignKey("Rid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RaunstrupAuth.Models.Tilbud", "T")
                        .WithMany("Medarbejderliste")
                        .HasForeignKey("Tid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Projekt", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Tilbud", "T")
                        .WithMany("Projekt")
                        .HasForeignKey("Tid");
                });

            modelBuilder.Entity("RaunstrupAuth.Models.Tilbud", b =>
                {
                    b.HasOne("RaunstrupAuth.Models.Kunde", "K")
                        .WithMany("Tilbud")
                        .HasForeignKey("Kid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RaunstrupAuth.Models.Rabat", "R")
                        .WithMany("Tilbud")
                        .HasForeignKey("Rid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
