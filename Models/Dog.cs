using System;
 using System.Collections.Generic;
 using System.Security.Policy;
 
 namespace DogShelter.Models
 {
     public class Dog
     {
         public int ID { get; set; }
         public string Name { get; set; }
         public DateTime Dob { get; set; }
         public string Breed { get; set; }
         public char Sex { get; set; }
         public string Summary { get; set; }
         public string ImageUrl { get; set; }

         public ICollection<Adoption> Adoptions{ get; set; }

     }
 }