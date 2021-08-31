using Microsoft.EntityFrameworkCore;
using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Context
{
    public class MyContext : DbContext // gateway/jembatan aplikasi dengan database
    {
        public MyContext(DbContextOptions<MyContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Person)
                .HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Profiling)
                .WithOne(pf => pf.Account)
                .HasForeignKey<Profiling>(pf => pf.NIK);
            modelBuilder.Entity<Education>()
                .HasMany(e => e.Profilings)
                .WithOne(pf => pf.Education);
            modelBuilder.Entity<University>()
                .HasMany(u => u.Educations)
                .WithOne(e => e.University);

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
