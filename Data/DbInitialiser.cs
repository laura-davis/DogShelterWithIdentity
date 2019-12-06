using DogShelter.Data;
using DogShelter.Models;
using System;
using System.Linq;

namespace DogShelter.Data

{
    public static class DbInitialiser
    {
        public static void Initialise(ShelterContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Dogs.Any())
            {
                return; // DB has been seeded
            }

            var dogs = new Dog[]
            {
                new Dog
                {
                    Name = "Gizmo", Dob = DateTime.Parse("2012-12-25"), Breed = "Mixed", Sex = "m",
                    Summary = "A cute and fluffy dog", ImageUrl = "www.gizmo.com/gizmo.jpg"
                },
                new Dog
                {
                    Name = "Dexter", Dob = DateTime.Parse("2016-02-14"), Breed = "Chow Chow", Sex = "m",
                    Summary = "Even fluffier!", ImageUrl = "www.dexter.com/dexter.jpg"
                }
            };
            foreach (Dog d in dogs)
            {
                context.Dogs.Add(d);
            }

            context.SaveChanges();

            var users = new User[]
            {
                new User
                {
                    FirstName = "Vik", LastName = "Mezei", AddressLine1 = "Syon Lane Castle",
                    Postcode = "TW97QD", Email = "ilovemario@gmail.com", Telephone = "1234567890", IsAdmin = true
                },

                new User
                {
                    FirstName = "Claire", LastName = "Cunliffe", AddressLine1 = "Tooting Palace",
                    Postcode = "SW1A2BC",
                    Email = "yogaiscool@gmail.com", Telephone = "2345678901", IsAdmin = true
                }
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

            var adoptions = new Adoption[]
            {
                new Adoption { },
            };
            foreach (Adoption a in adoptions)
            {
                context.Adoptions.Add(a);
            }

            context.SaveChanges();
        }
    }
}