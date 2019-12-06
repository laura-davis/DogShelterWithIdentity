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

        public DbSet<DogShelter.Models.Dog> Dog { get; set; }
    }
}
