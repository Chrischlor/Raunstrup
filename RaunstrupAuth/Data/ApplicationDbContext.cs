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
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<RaunstrupAuth.Models.Materialer> Materialer { get; set; }
    }
}
