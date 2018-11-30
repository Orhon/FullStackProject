using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eindproject2.Models.Data
{
    public class Eindproject2APIContext : IdentityDbContext<Users>
    {
        public Eindproject2APIContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Userplans> Userplans { get; set; }
        public DbSet<Userinfo> Userinfo { get; set; }
        public DbSet<Plans> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Userplans>().ToTable("Userplans");
            modelBuilder.Entity<Userinfo>().ToTable("Userinfo");
            modelBuilder.Entity<Plans>().ToTable("Plans");
            modelBuilder.Entity<Userplans>().HasKey(pa => new { pa.UserID, pa.PlanID });
            modelBuilder.Seed();
        }
    }
}
