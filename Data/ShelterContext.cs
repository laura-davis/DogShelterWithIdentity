using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogShelter.Models;

namespace DogShelter.Data
{
    public class ShelterContext : DbContext
    {
        public ShelterContext (DbContextOptions<ShelterContext> options)
            : base(options)
        {
        }
        
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adoption>().ToTable("Adoption");
            modelBuilder.Entity<Dog>().ToTable("Dog");
            modelBuilder.Entity<User>().ToTable("User");
        }
        public DbSet<DogShelter.Models.Dog> Dog { get; set; }
    }
}
