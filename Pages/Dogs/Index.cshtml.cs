using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogShelter.Data;
using DogShelter.Models;

namespace DogShelter.Pages.Dogs
{
    public class IndexModel : PageModel
    {
        private readonly DogShelter.Data.ShelterContext _context;

        public IndexModel(DogShelter.Data.ShelterContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Dog> Dog { get; set; }

        
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            
            CurrentFilter = searchString;
            
            IQueryable<Dog> dogsIq = from d in _context.Dogs
                select d;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                dogsIq = dogsIq.Where(d => d.Name.Contains(searchString)
                                                   || d.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    dogsIq = dogsIq.OrderByDescending(d => d.Name);
                    break;
                case "Date":
                    dogsIq = dogsIq.OrderBy(d => d.Dob);
                    break;
                case "date_desc":
                    dogsIq = dogsIq.OrderByDescending(d => d.Dob);
                    break;
                default:
                    dogsIq = dogsIq.OrderBy(d => d.Name);
                    break;
            }

            Dog = await dogsIq.AsNoTracking().ToListAsync();
        }
    }
}